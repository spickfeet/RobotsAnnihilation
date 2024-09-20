using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Utilities.Sounds
{
    public interface IVolumeSettings
    {
        float MasterVolume { get; set; }
        float MusicVolume { get; set; }
        float SFXVolume { get; set; }
    }
}
