using MelonLoader;

[assembly: MelonInfo(typeof(PGLab.Main), "PGLab", "1.0.0", "PGLab")]
[assembly: MelonGame("Stress Level Zero", "BONELAB")]

namespace PGLab
{
    /// <summary>
    /// Main class for the PGLab mod.
    /// </summary>
    public class Main : MelonMod
    {
        /// <summary>
        /// Called when the mod is initialized.
        /// </summary>
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("Making BONELAB PG...");
            NoBlood.NoBloodPatches.ApplyPatches(this);
            Softbody.BreastPatches.ApplyPatches(this);
            Softbody.ButtPatches.ApplyPatches(this);
            MelonLogger.Msg("Finished making BONELAB PG.");
        }
    }
}