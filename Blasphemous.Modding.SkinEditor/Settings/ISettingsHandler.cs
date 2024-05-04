
namespace Blasphemous.Modding.SkinEditor.Settings;

public interface ISettingsHandler
{
    EditorSettings Current { get; }

    void Save();

    void Load();
}
