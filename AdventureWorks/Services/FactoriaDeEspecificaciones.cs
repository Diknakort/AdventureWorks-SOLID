using AdventureWorks.Models;

namespace AdventureWorks.Services
{
    public class FactoriaDeEspecificaciones : ISpecificacionFactory
    {
        public IProductSpecification dameInstancia(EnumeracionEjercicios ejercicio)
        {
            IProductSpecification especificacion = null;
            switch (ejercicio)
            {
                case EnumeracionEjercicios.Ejercicio1:
                {
                    especificacion = new Ejercicio01Builder();
                    break;
                }
                case EnumeracionEjercicios.Ejercicio2:
                {
                    especificacion = new Ejercicio02Builder();
                    break;
                }
                case EnumeracionEjercicios.Ejercicio3:
                {
                    especificacion = new Ejercicio03Builder();
                    break;
                    return new Ejercicio03Builder();
                }
                case EnumeracionEjercicios.Ejercicio4:
                {
                    especificacion = new Ejercicio04Builder();
                    break;
                }
            }

            return especificacion;
        }

    }
}
