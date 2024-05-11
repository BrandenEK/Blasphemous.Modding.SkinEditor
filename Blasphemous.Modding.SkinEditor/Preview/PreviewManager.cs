﻿using Blasphemous.Modding.SkinEditor.Undo;
using System.Drawing.Imaging;

namespace Blasphemous.Modding.SkinEditor.Preview;

public class PreviewManager : IManager
{
    private readonly PictureBox _pictureBox;
    private readonly ComboBox _selector;

    private Bitmap? _indexedPreview;
    private Bitmap? _coloredPreview;
    private int _lastScale = 1;

    private int CurrentScale => _coloredPreview == null
        ? -1
        : Math.Min(_pictureBox.Size.Width / _coloredPreview!.Width, _pictureBox.Size.Height / _coloredPreview.Height);

    public PreviewManager(PictureBox pictureBox, ComboBox selector)
    {
        LoadAllAnimations(selector);

        _pictureBox = pictureBox;
        _pictureBox.SizeChanged += OnPictureResized;
        _selector = selector;
        _selector.SelectedIndexChanged += OnSelectionChanged;
    }

    private void LoadFirstPreview()
    {
        ChangePreview(FIRST_ANIM, true);
    }

    private void LoadAllAnimations(ComboBox selector)
    {
        foreach (string file in Embedder.GetResourcesInFolder("previews"))
        {
            string name = file[..^4];
            Logger.Info($"Loaded anim: {name}");
            selector.Items.Add(name);
        }

        selector.SelectedItem = FIRST_ANIM;
    }

    private void OnPictureResized(object? _, EventArgs __)
    {
        if (_coloredPreview == null || _pictureBox.Image == null || _lastScale == CurrentScale)
            return;

        Logger.Warn("Resizing preview image");
        DisplayPreview(_coloredPreview);
    }

    private void OnSelectionChanged(object? _, EventArgs __)
    {
        ChangePreview(_selector.SelectedItem.ToString()!, false);
    }

    private void SetBackgroundColor(bool dark)
    {
        Color color = ColorTranslator.FromHtml(dark ? "#110803" : "#202020");
        _pictureBox.BackColor = color;
        _pictureBox.Parent.BackColor = color;
    }

    private void DisplayPreview(Bitmap preview)
    {
        int currentScale = CurrentScale;
        Bitmap newPreview = ScalePreview(preview, currentScale);

        _pictureBox.Enabled = false;
        _pictureBox.Image?.Dispose();
        _pictureBox.Image = newPreview;
        _pictureBox.Enabled = true;

        _lastScale = currentScale;
    }

    private Bitmap ScalePreview(Bitmap preview, int factor)
    {
        factor = Math.Max(factor, 1);
        Bitmap scaled = new(preview.Width * factor, preview.Height * factor);

        for (int x = 0; x < scaled.Width; x++)
        {
            for (int y = 0; y < scaled.Height; y++)
            {
                scaled.SetPixel(x, y, preview.GetPixel(x / factor, y / factor));
            }
        }

        return scaled;
    }

    private Bitmap ColorPreview(Bitmap preview)
    {
        Bitmap colored = new(preview.Width, preview.Height);

        for (int x = 0; x < colored.Width; x++)
        {
            for (int y = 0; y < colored.Height; y++)
            {
                Color pixelColor = preview.GetPixel(x, y);
                if (pixelColor.A > 0)
                {
                    colored.SetPixel(x, y, Core.TextureManager.GetPixel(pixelColor.R));
                }
            }
        }

        return colored;
    }

    public void ChangePreview(string name, bool updateSelector)
    {
        ChangePreview(Embedder.LoadResourceImage($"previews.{name}.png"));

        if (updateSelector)
            _selector.SelectedItem = name;
    }

    public void ChangePreview(Bitmap preview)
    {
        // Store the indexed preview
        _indexedPreview?.Dispose();
        _indexedPreview = preview;

        // Color and store the colored preview
        _coloredPreview?.Dispose();
        _coloredPreview = ColorPreview(preview);

        // Update display
        Logger.Info("Changing preview image");
        DisplayPreview(_coloredPreview);
        OnPreviewChanged?.Invoke();
    }

    public void UpdatePreview(int pixel, Color color)
    {
        if (_coloredPreview == null || _indexedPreview == null)
            return;

        for (int x = 0; x < _coloredPreview.Width; x++)
        {
            for (int y = 0; y < _coloredPreview.Height; y++)
            {
                Color pixelColor = _indexedPreview.GetPixel(x, y);
                if (pixelColor.A > 0 && pixelColor.R == pixel)
                {
                    _coloredPreview.SetPixel(x, y, color);
                }
            }
        }

        DisplayPreview(_coloredPreview);
    }

    public void UpdatePreview(Bitmap texture)
    {
        if (_coloredPreview == null || _indexedPreview == null)
            return;

        for (int x = 0; x < _coloredPreview.Width; x++)
        {
            for (int y = 0; y < _coloredPreview.Height; y++)
            {
                Color pixelColor = _indexedPreview.GetPixel(x, y);
                if (pixelColor.A > 0)
                {
                    _coloredPreview.SetPixel(x, y, texture.GetPixel(pixelColor.R, 0));
                }
            }
        }

        DisplayPreview(_coloredPreview);
    }

    private void SavePreview(string path)
    {
        using Bitmap export = Embedder.LoadResourceImage("preview.png");

        for (int i = 0; i < export.Width; i++)
        {
            for (int j = 0; j < export.Height; j++)
            {
                Color pixel = export.GetPixel(i, j);
                if (pixel.R != pixel.G || pixel.R != pixel.B)
                    continue;

                export.SetPixel(i, j, Core.TextureManager.GetPixel(pixel.R));
            }
        }

        Logger.Info($"Saving skin preview to {path}");
        export.Save(path, ImageFormat.Png);
    }

    public IEnumerable<byte> GetPixelsInPreview()
    {
        if (_indexedPreview == null)
            return Enumerable.Empty<byte>();

        List<byte> pixels = new();

        for (int x = 0; x < _indexedPreview.Width; x++)
        {
            for (int y = 0; y < _indexedPreview.Height; y++)
            {
                Color color = _indexedPreview.GetPixel(x, y);
                if (color.A > 0 && !pixels.Contains(color.R))
                    pixels.Add(color.R);
            }
        }

        return pixels;
    }

    // Event handling

    public void Initialize()
    {
        Core.RecolorManager.OnPixelChanged += OnPixelChanged;
        Core.SaveManager.OnNewSkin += OnNewSkin;
        Core.SaveManager.OnOpenSkin += OnOpenSkin;
        Core.SaveManager.OnSaveSkin += OnSaveSkin;
        Core.SettingManager.OnSettingChanged += OnSettingChanged;
        Core.TextureManager.OnTextureChanged += OnTextureChanged;
        Core.UndoManager.OnUndo += OnUndo;
        Core.UndoManager.OnRedo += OnRedo;
    }

    private void OnPixelChanged(byte pixel, Color oldColor, Color newColor)
    {
        UpdatePreview(pixel, newColor);
    }

    private void OnNewSkin()
    {
        LoadFirstPreview();
    }

    private void OnOpenSkin(string path)
    {
        LoadFirstPreview();
    }

    private void OnSaveSkin(string path)
    {
        SavePreview(Path.Combine(path, "preview.png"));
    }

    private void OnSettingChanged(string property, bool status, bool onLoad)
    {
        if (property != "view_background")
            return;

        SetBackgroundColor(status);
    }

    private void OnTextureChanged(Bitmap texture)
    {
        UpdatePreview(texture);
    }

    private void OnUndo(BaseUndoCommand command)
    {
        if (command is not PixelColorUndoCommand pc)
            return;

        UpdatePreview(pc.Pixel, pc.OldColor);
    }

    private void OnRedo(BaseUndoCommand command)
    {
        if (command is not PixelColorUndoCommand pc)
            return;

        UpdatePreview(pc.Pixel, pc.NewColor);
    }

    public delegate void PreviewChangeDelegate();
    public event PreviewChangeDelegate? OnPreviewChanged;

    private const string FIRST_ANIM = "idle";
}
