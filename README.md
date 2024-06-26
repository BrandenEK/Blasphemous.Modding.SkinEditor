# Blasphemous Skin Editor
<img src="https://img.shields.io/github/downloads/BrandenEK/Blasphemous.Modding.SkinEditor/total?color=248721&style=for-the-badge">

---

### Exporting

When exporting the skin texture, you need to specify this info:
- Id: Unique id of the skin that will never change and follows this format - "PENITENT_{*AUTHOR_INITIALS*}_{*SKIN_SHORT_NAME*}"
- Name: Full name of the skin
- Author: Name of the author
- Version: Latest version of the skin - Should start at 1.0.0

Example:
```
{
  "id": "PENITENT_RV_DEFORMITY",
  "name": "Voice of the Deformity",
  "author": "Raider",
  "version": "1.0.0"
}
```

---

### Community Repo

Once you have created a custom skin, consider adding it to the [community repo](https://github.com/BrandenEK/Blasphemous-Custom-Skins) so that other people can download it through the mod installer.
To do this, simply fork the repository, add your custom skins, then submit a pull request.

---

### Command line arguments
- ```-[d]ebug``` Runs the editor in debug mode with a console
- ```-[r]esources {path}``` Loads editor resources from custom directory
