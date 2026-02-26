using System;
using System.Collections.Generic;

namespace Gestor_de_Horarios_de_Maestros
{
    public class HorarioSimple
    {
        public string Maestro { get; set; }
        public string Dia { get; set; }
        public int HoraInicio { get; set; } // Corregido: HoraInicio
        public int HoraFin { get; set; }
    }

    public class ValidadorHorarios
    {
        public static bool HayChoque(HorarioSimple nuevo, List<HorarioSimple> existentes, out string mensaje)
        {
            foreach (var h in existentes)
            {
                if (h.Maestro == nuevo.Maestro && h.Dia == nuevo.Dia)
                {
                    bool seCruzan = nuevo.HoraInicio < h.HoraFin && nuevo.HoraFin > h.HoraInicio;
                    if (seCruzan)
                    {
                        mensaje = $"El maestro {nuevo.Maestro} ya tiene clase el {h.Dia} de {h.HoraInicio}:00 a {h.HoraFin}:00.";
                        return true;
                    }
                }
            }
            mensaje = "";
            return false;
        }
    }
}
