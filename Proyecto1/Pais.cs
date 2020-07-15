using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Pais
    {
        private String nombrePais;
        private String poblacion;
        private String rutaBandera;
        private String saturacion;
        private String continente;
        public Pais()
        {
        }
        public Pais(String nombrePais, String poblacion, String rutaBandera, String saturacion, String continente)
        {
            this.nombrePais = nombrePais;
            this.poblacion = poblacion;
            this.rutaBandera = rutaBandera;
            this.saturacion = saturacion;
            this.continente = continente;
        }
        public void setContinente(String continente)
        {
            this.continente = continente;
        }
        public String getContinente()
        {
            return continente;
        }
        public String getSaturacion()
        {
            return saturacion;
        }
        public void setSaturacion(String saturacion)
        {
            this.saturacion = saturacion;
        }
        public String getNombrePais()
        {
            return nombrePais;
        }
        public String getRutaBandera()
        {
            return rutaBandera;
        }
        public String getPoblacion()
        {
            return poblacion;
        }
        public void setNombrePais(String nombrePais)
        {
            this.nombrePais = nombrePais;
        }
        public void setPoblacion(String poblacion)
        {
            this.poblacion = poblacion;
        }
        public void setRutaBandera(String rutaBandera)
        {
            this.rutaBandera = rutaBandera;
        }
    }
}
