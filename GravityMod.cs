using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(GravityMod.GravityMod), "GravityMod", "0.3.0", "YourName")]
[assembly: MelonGame("New Folder Games", "I Am Cat")]

namespace GravityMod
{
    public class GravityMod : MelonMod
    {
        // Preferences category for grouping our settings
        private MelonPreferences_Category _category;

        // Entry for the gravity multiplier (Physics.gravity will be multiplied by this)
        private MelonPreferences_Entry<float> _gravityMultiplier;

        // Ensure we only apply gravity once per game session
        private bool _hasAppliedGravity = false;

        /// <summary>
        /// Called once when the mod is initialized.
        /// Set up the preferences file and default entries.
        /// </summary>
        public override void OnInitializeMelon()
        {
            // Create (or load) a preferences category named "GravityMod"
            _category = MelonPreferences.CreateCategory("GravityMod");

            // Create an entry named "GravityMultiplier" with a default of 0.1f
            // This value determines how much to scale the game's default gravity
            _gravityMultiplier = _category.CreateEntry(
                "GravityMultiplier",
                0.1f,
                "Multiplier applied to Physics.gravity"
            );

            // Write the category and entries to disk (generates the .cfg file if it doesn't exist)
            _category.SaveToFile();

            MelonLogger.Msg($"[GravityMod] Preferences loaded: GravityMultiplier = {_gravityMultiplier.Value:F2}");
        }

        /// <summary>
        /// Called whenever a new scene is loaded.
        /// Apply our custom gravity on the first real game scene.
        /// </summary>
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            // Skip menus/loading scenes (assumed to be buildIndex < 1)
            if (_hasAppliedGravity || buildIndex < 1)
                return;

            // Retrieve the multiplier from the config
            float multiplier = _gravityMultiplier.Value;

            // Read the original gravity, apply the multiplier, and set it back
            Vector3 originalGravity = Physics.gravity;
            Vector3 newGravity = originalGravity * multiplier;
            Physics.gravity = newGravity;

            MelonLogger.Msg($"[GravityMod] Physics.gravity changed from {originalGravity} to {newGravity} in scene '{sceneName}'");

            _hasAppliedGravity = true;
        }
    }
}









































































