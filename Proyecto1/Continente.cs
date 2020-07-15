using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Continente
    {
        private String continente;
        private String saturacion;
        private String numPaises;
        private Pais pais;
        public Continente(String continente, String saturacion, String numPaises)
        {
            this.continente = continente;
            this.saturacion = saturacion;
            this.numPaises = numPaises;
        }
        public Continente(String continente, String saturacion, String numPaises, Pais pais)
        {
            this.continente = continente;
            this.saturacion = saturacion;
            this.numPaises = numPaises;
            this.pais = pais;
        }
        public Pais getPais()
        {
            return pais;
        }
        
        public Continente(String continente)
        {
            this.continente = continente;
        }
        public Continente()
        {
        }
        public String getNumPais()
        {
            return numPaises;
        }
        public void setPais(String pais)
        {
            this.numPaises = numPaises;
        }
        public void setContinente(String continente)
        {
            this.continente = continente;
        }
        public void setSaturacion(String saturacion)
        {
            this.saturacion = saturacion;
        }
        public String getContinente()
        {
            return continente;
        }
        public String getSaturacion()
        {
            return saturacion;
        }
    }
}
