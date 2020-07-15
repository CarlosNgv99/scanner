using System;

namespace Proyecto1
{
    class Token
    {
        public enum Tipo
        {
            ID_NOMBRE,
            ID_GRAFICA,
            ID_PAIS,
            ID_CONTINENTE,
            ID_POBLACION,
            ID_SATURACION,
            ID_BANDERA,
            NUMERO_ENTERO,
            NUMERO_PORCENTAJE,
            BRACKET_DER,
            BRACKET_IZQ,
            DOS_PUNTOS,
            LLAVE_DER,
            LLAVE_IZQ,
            PUNTO_Y_COMA,
            CADENA,
            DESCONOCIDO
        }
        private Tipo tipoToken;
        private String valor;
        private int idToken;
        public Token()
        {

        }
        public Token(Tipo tipoToken, String valor, int idToken)
        {
            this.tipoToken = tipoToken;
            this.valor = valor;
            this.idToken = idToken;
        }
        public int getIdToken()
        {
            return idToken;
        }
        public String getValor()
        {
            return valor;
        }

        public String getTipo()
        {
            switch (tipoToken)
            {
                case Tipo.ID_NOMBRE:
                    return "Reservada Nombre";
                case Tipo.ID_PAIS:
                    return "Reservada Pais";
                case Tipo.ID_POBLACION:
                    return "Reservada Poblacion";
                case Tipo.ID_SATURACION:
                    return "Reservada Saturacion";
                case Tipo.ID_GRAFICA:
                    return "Reservada Grafica";
                case Tipo.ID_BANDERA:
                    return "Reservada Bandera";
                case Tipo.ID_CONTINENTE:
                    return "Reservada Continente";
                case Tipo.BRACKET_DER:
                    return "Bracket derecho";
                case Tipo.BRACKET_IZQ:
                    return "Bracket izquierdo";
                case Tipo.DOS_PUNTOS:
                    return "Dos puntos";
                case Tipo.NUMERO_ENTERO:
                    return "Numero entero";
                case Tipo.LLAVE_DER:
                    return "Llave derecha";
                case Tipo.LLAVE_IZQ:
                    return "Llave izquierda";
                case Tipo.CADENA:
                    return "Cadena";
                case Tipo.NUMERO_PORCENTAJE:
                    return "Numero porcentaje";
                case Tipo.DESCONOCIDO:
                    return "Desconocido";
                default:
                    return "";
            }
        }
    }
}
