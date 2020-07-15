using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Analizador
    {
        private LinkedList<Token> Salida;
        private LinkedList<Token> errorSalida;
        private int estado;
        private String auxLex;
        private int idToken;
        public LinkedList<Token> escanear(String entrada)
        {
            entrada = entrada + "´";
            Salida = new LinkedList<Token>();
            errorSalida = new LinkedList<Token>();
            auxLex = "";
            char c;
            int posicion=0;
            estado = 0;
            for (int i = 0; i <= entrada.Length - 1; i++)
            {
                c = entrada.ElementAt(i);
                switch (estado)
                {

                    case 0:
                        /*Identificadores*/
                        if (c.CompareTo('G') == 0)
                        {
                            estado = 1;
                            auxLex += c;
                        }
                        else if (c.CompareTo('g') == 0)
                        {
                            estado = 0;
                            auxLex += c;
                            agregarError(Token.Tipo.DESCONOCIDO);
                        }
                        else if (c.CompareTo('N') == 0)
                        {
                            estado = 7;
                            auxLex += c;
                        }
                        else if (c.CompareTo('n') == 0)
                        {
                            estado = 0;
                            auxLex += c;
                            agregarError(Token.Tipo.DESCONOCIDO);
                        }
                        else if (c.CompareTo('C') == 0)
                        {
                            estado = 12;
                            auxLex += c;
                        }
                        else if (c.CompareTo('c') == 0)
                        {
                            estado = 0;
                            auxLex += c;
                            agregarError(Token.Tipo.DESCONOCIDO);
                        }
                        else if (c.CompareTo('P') == 0)
                        {
                            estado = 21;
                            auxLex += c;
                        }
                        else if (c.CompareTo('p') == 0)
                        {
                            estado = 0;
                            auxLex += c;
                            agregarError(Token.Tipo.DESCONOCIDO);
                        }
                        else if (c.CompareTo('S') == 0)
                        {
                            estado = 31;
                            auxLex += c;
                        }
                        else if (c.CompareTo('s') == 0)
                        {
                            estado = 0;
                            auxLex += c;
                            agregarError(Token.Tipo.DESCONOCIDO);
                        }
                        else if (c.CompareTo('B') == 0)
                        {
                            estado = 40;
                            auxLex += c;
                        }
                        else if (c.CompareTo('b') == 0)
                        {
                            estado = 0;
                            auxLex += c;
                            agregarError(Token.Tipo.DESCONOCIDO);
                        }
                        /*Numero entero*/
                        else if (Char.IsDigit(c))
                        {
                            auxLex += c;
                            estado = 47;
                        }
                        /*Simbolos*/
                        else if (c.CompareTo('{') == 0)
                        {
                            auxLex += c;
                            agregarToken(Token.Tipo.LLAVE_IZQ);

                        }
                        else if (c.CompareTo('}') == 0)
                        {
                            auxLex += c;
                            agregarToken(Token.Tipo.LLAVE_DER);

                        }
                        else if (c.CompareTo(':') == 0)
                        {
                            auxLex += c;
                            agregarToken(Token.Tipo.DOS_PUNTOS);

                        }
                        /*Cadena de caracteres*/
                        else if (c.CompareTo('"') == 0)
                        {
                            // auxLex += c;
                            estado = 46;
                        }
                        else if (c.CompareTo('#') == 0)
                        {
                            auxLex += c;
                            agregarError(Token.Tipo.DESCONOCIDO);

                        }
                        else if (c.CompareTo('@') == 0)
                        {
                            auxLex += c;

                            agregarError(Token.Tipo.DESCONOCIDO);

                        }
                        else if (c.CompareTo('$') == 0)
                        {
                            auxLex += c;

                            agregarError(Token.Tipo.DESCONOCIDO);

                        }
                        else if (c.CompareTo('|') == 0)
                        {
                            auxLex += c;

                            agregarError(Token.Tipo.DESCONOCIDO);

                        }
                        else if (c.CompareTo('°') == 0)
                        {
                            auxLex += c;

                            agregarError(Token.Tipo.DESCONOCIDO);

                        }
                        else if (c.CompareTo('*') == 0)
                        {
                            auxLex += c;

                            agregarError(Token.Tipo.DESCONOCIDO);

                        }
                        else if (c.CompareTo('<') == 0)
                        {
                            auxLex += c;

                            agregarError(Token.Tipo.DESCONOCIDO);

                        }
                        else if (c.CompareTo('>') == 0)
                        {
                            auxLex += c;

                            agregarError(Token.Tipo.DESCONOCIDO);

                        }
                        else
                        {

                            if (c.CompareTo('´') == 0 && i == entrada.Length - 1)
                            {
                                Console.WriteLine("Análisis terminado.");
                            }
                            else
                            {
                                estado = 0;
                            }
                        }
                        break;
                    case 1:
                        if (c.CompareTo('r') == 0)
                        {
                            auxLex += c;
                            estado = 2;
                        }
                        else
                        {
                            agregarToken(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;

                        }
                        break;
                    case 2:
                        if (c.CompareTo('a') == 0)
                        {
                            auxLex += c;
                            estado = 3;
                        }
                        else
                        {
                            agregarToken(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 3:
                        if (c.CompareTo('f') == 0)
                        {
                            auxLex += c;
                            estado = 4;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;

                        }
                        break;
                    case 4:
                        if (c.CompareTo('i') == 0)
                        {
                            auxLex += c;
                            estado = 5;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;

                        }
                        break;
                    case 5:
                        if (c.CompareTo('c') == 0)
                        {
                            auxLex += c;
                            estado = 6;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;

                        }
                        break;
                    case 6:
                        if (c.CompareTo('a') == 0)
                        {
                            auxLex += c;
                            agregarToken(Token.Tipo.ID_GRAFICA);
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            auxLex = "";
                            estado = 0;
                        }
                        break;
                    case 7:
                        if (c.CompareTo('o') == 0)
                        {
                            auxLex += c;
                            estado = 8;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 8:
                        if (c.CompareTo('m') ==0)
                        {
                            auxLex += c;
                            estado = 9;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 9:
                        if (c.CompareTo('b') ==0)
                        {
                            auxLex += c;
                            estado = 10;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 10:
                        if (c.CompareTo('r') == 0)
                        {
                            auxLex += c;
                            estado = 11;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 11:
                        if (c.CompareTo('e') == 0)
                        {
                            auxLex += c;
                            agregarToken(Token.Tipo.ID_NOMBRE);
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            auxLex = "";
                            estado = 0;
                        }
                        break;
                    case 12:
                        if (c.CompareTo('o') == 0)
                        {
                            auxLex += c;
                            estado = 13;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 13:
                        if (c.CompareTo('n') == 0)
                        {
                            auxLex += c;
                            estado = 14;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 14:
                        if (c.CompareTo('t') == 0)
                        {
                            auxLex += c;
                            estado = 15;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 15:
                        if (c.CompareTo('i') == 0)
                        {
                            auxLex += c;
                            estado = 16;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 16:
                        if (c.CompareTo('n') == 0)
                        {
                            auxLex += c;
                            estado = 17;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 17:
                        if (c.CompareTo('e') == 0)
                        {
                            auxLex += c;
                            estado = 18;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 18:
                        if (c.CompareTo('n') == 0)
                        {
                            auxLex += c;
                            estado = 19;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 19:
                        if (c.CompareTo('t') == 0)
                        {
                            auxLex += c;
                            estado = 20;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 20:
                        if (c.CompareTo('e') == 0)
                        {
                            auxLex += c;
                            agregarToken(Token.Tipo.ID_CONTINENTE);
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            auxLex = "";
                            estado = 0;
                        }
                        break;
                    case 21:
                        if (c.CompareTo('a') == 0)
                        {
                            auxLex += c;
                            estado = 22;
                        }
                        else if(c.CompareTo('o') == 0)
                        {
                            auxLex += c;
                            estado = 24;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 22:
                        if (c.CompareTo('i') == 0)
                        {
                            auxLex += c;
                            estado = 23;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 23:
                        if (c.CompareTo('s') == 0)
                        {
                            auxLex += c;
                            agregarToken(Token.Tipo.ID_PAIS);
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            auxLex = "";
                            estado = 0;
                        }
                        break;
                    case 24:
                        if (c.CompareTo('b') == 0)
                        {
                            auxLex += c;
                            estado = 25;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 25:
                        if (c.CompareTo('l') == 0)
                        {
                            auxLex += c;
                            estado = 26;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 26:
                        if (c.CompareTo('a') == 0)
                        {
                            auxLex += c;
                            estado = 27;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 27:
                        if (c.CompareTo('c') == 0)
                        {
                            auxLex += c;
                            estado = 28;
                        }
                        else
                        {
                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 28:
                        if (c.CompareTo('i') == 0)
                        {
                            auxLex += c;
                            estado = 29;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 29:
                        if (c.CompareTo('o') == 0)
                        {
                            auxLex += c;
                            estado = 30;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 30:
                        if (c.CompareTo('n') == 0)
                        {
                            auxLex += c;
                            agregarToken(Token.Tipo.ID_POBLACION);
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            auxLex = "";
                            estado = 0;
                        }
                        break;
                    case 31:
                        if (c.CompareTo('a') == 0)
                        {
                            auxLex += c;
                            estado = 32;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 32:
                        if (c.CompareTo('t') == 0)
                        {
                            auxLex += c;
                            estado = 33;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 33:
                        if (c.CompareTo('u') == 0)
                        {
                            auxLex += c;
                            estado = 34;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);

                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 34:
                        if (c.CompareTo('r') == 0)
                        {
                            auxLex += c;
                            estado = 35;
                        }
                        else
                        {
                            agregarError(Token.Tipo.DESCONOCIDO);
                            Console.WriteLine("Error léxico con: " + c);
                            estado = 0;
                        }
                        break;
                    case 35:
                        if (c.CompareTo('a') == 0)
                        {
                            auxLex += c;
                            estado = 36;
                        }
                        else
                        {
                            Console.WriteLine("Error léxico con: " + c);
                            agregarError(Token.Tipo.DESCONOCIDO);

                            estado = 0;
                        }
                        break;
                    case 36:
                        if (c.CompareTo('c') == 0)
                        {
                            auxLex += c;
                            estado = 37;
                        }
                        else
                        {
                            Console.WriteLine("Error léxico con: " + c);
                            agregarError(Token.Tipo.DESCONOCIDO);

                            estado = 0;
                        }
                        break;
                    case 37:
                        if (c.CompareTo('i') == 0)
                        {
                            auxLex += c;
                            estado = 38;
                        }
                        else
                        {
                            Console.WriteLine("Error léxico con: " + c);
                            agregarError(Token.Tipo.DESCONOCIDO);

                            estado = 0;
                        }
                        break;
                    case 38:
                        if (c.CompareTo('o') == 0)
                        {
                            auxLex += c;
                            estado = 39;
                        }
                        else
                        {
                            Console.WriteLine("Error léxico con: " + c);
                            agregarError(Token.Tipo.DESCONOCIDO);

                            estado = 0;
                        }
                        break;
                    case 39:
                        if (c.CompareTo('n') == 0)
                        {
                            auxLex += c;
                            agregarToken(Token.Tipo.ID_SATURACION);
                        }
                        else
                        {
                            Console.WriteLine("Error léxico con: " + c);
                            agregarError(Token.Tipo.DESCONOCIDO);

                            auxLex = "";
                            estado = 0;
                        }
                        break;
                    case 40:
                        if (c.CompareTo('a') == 0)
                        {
                            auxLex += c;
                            estado = 41;
                        }
                        else
                        {
                            Console.WriteLine("Error léxico con: " + c);
                            agregarError(Token.Tipo.DESCONOCIDO);

                            estado = 0;
                        }
                        break;
                    case 41:
                        if (c.CompareTo('n') == 0)
                        {
                            auxLex += c;
                            estado = 42;
                        }
                        else
                        {
                            Console.WriteLine("Error léxico con: " + c);
                            agregarError(Token.Tipo.DESCONOCIDO);

                            estado = 0;
                        }
                        break;
                    case 42:
                        if (c.CompareTo('d') == 0)
                        {
                            auxLex += c;
                            estado = 43;
                        }
                        else
                        {
                            Console.WriteLine("Error léxico con: " + c);
                            agregarError(Token.Tipo.DESCONOCIDO);

                            estado = 0;
                        }
                        break;
                    case 43:
                        if (c.CompareTo('e') == 0)
                        {
                            auxLex += c;
                            estado = 44;
                        }
                        else
                        {
                            Console.WriteLine("Error léxico con: " + c);
                            agregarError(Token.Tipo.DESCONOCIDO);

                            estado = 0;
                        }
                        break;
                    case 44:
                        if (c.CompareTo('r') == 0)
                        {
                            auxLex += c;
                            estado = 45;
                        }
                        else
                        {
                            Console.WriteLine("Error léxico con: " + c);
                            agregarError(Token.Tipo.DESCONOCIDO);

                            estado = 0;
                        }
                        break;
                    case 45:
                        if (c.CompareTo('a') == 0)
                        {
                            auxLex += c;
                            agregarToken(Token.Tipo.ID_BANDERA);
                        }
                        else
                        {
                            Console.WriteLine("Error léxico con: " + c);
                            agregarError(Token.Tipo.DESCONOCIDO);
                            auxLex = "";
                            estado = 0;
                        }
                        break;
                    case 46:
                        if (c.CompareTo('"') == 0)
                        {
                           //auxLex += c;
                            agregarToken(Token.Tipo.CADENA);
                            idToken = 12;
                        }
                        else
                        {
                            estado = 46;
                            auxLex += c;
                        }
                        break;
                    case 47:
                        if (Char.IsDigit(c))
                        {
                            estado = 47;
                            auxLex += c;
                        }else if (c.CompareTo('%')==0)
                        {
                            //auxLex += c;
                            agregarToken(Token.Tipo.NUMERO_PORCENTAJE);
                        }
                        else
                        {
                            agregarToken(Token.Tipo.NUMERO_ENTERO);

                        }
                        break;
                }

            }
            if (errorSalida.Count > 0)
            {
                return errorSalida;
            }
            else
            {
                return Salida;
            }
        }
        public void agregarToken(Token.Tipo tipo)
        {
            Salida.AddLast(new Token(tipo, auxLex, idToken));
            auxLex = "";
            estado = 0;
        }
        public void agregarError(Token.Tipo tipo)
        {
            errorSalida.AddLast(new Token(tipo, auxLex, idToken));
            auxLex = "";
            estado = 0;
        }
        
        public void imprimirTokens(LinkedList<Token> lista)
        {
            int r = 1;
            int n = 1;
            try
            {
                if (errorSalida.Count > 0)
                {
                   
                    List<string> lines = new List<string>();
                    lines.Add("<!DOCTYPE html>");
                    lines.Add("<html>");
                    lines.Add("<head>");
                    lines.Add("<style>");
                    lines.Add("table{");
                    lines.Add("border-collapse: collapse;");
                    lines.Add(" width: 50%;}");
                    lines.Add("th, td {");
                    lines.Add("text - align: left;");
                    lines.Add(" padding: 4px;}");
                    lines.Add("th{");
                    lines.Add("background-color:black;");
                    lines.Add("color:white;}");
                    lines.Add("</style>");
                    lines.Add("<title>");
                    lines.Add("Errores");
                    lines.Add("</title>");
                    lines.Add("</head>");
                    lines.Add("<style>");
                    lines.Add("table, th, td{ border: 1px solid black; border-collapse: separate; }");
                    lines.Add("</style>");
                    lines.Add("<body>");
                    lines.Add("<h1>Errores</h1>");
                    lines.Add("<table>");
                    lines.Add("<tr>");
                    lines.Add("<th>" + "No." + "</th>");
                    lines.Add("<th>" + "Error" + "</th>");
                    lines.Add("<th>" + "Descripción" + "</th>");
                    lines.Add("</tr>");
                    foreach (Token item2 in lista)
                    {
                        lines.Add("<tr>");
                        if (item2.getTipo().Equals("Desconocido"))
                        {
                            lines.Add("<td>" + (n++) + "</td>");
                            lines.Add("<td>" + (item2.getValor()) + "</td>");
                            lines.Add("<td>" + ("Caracter desconocido" + "</td>"));
                        }
                        lines.Add("</tr>");
                    }
                    lines.Add("</table>");
                    lines.Add("</body>");
                    lines.Add("</html>");
                    File.WriteAllLines("Errores.html", lines);
                    System.Diagnostics.Process.Start(@"../debug/Errores.html");
                }
                else
                {
                    List<string> lines = new List<string>();
                    lines.Add("<!DOCTYPE html>");
                    lines.Add("<html>");
                    lines.Add("<head>");
                    lines.Add("<style>");
                    lines.Add("table{");
                    lines.Add("border-collapse: collapse;");
                    lines.Add(" width: 50%;}");
                    lines.Add("th, td {");
                    lines.Add("text - align: left;");
                    lines.Add(" padding: 4px;}");
                    lines.Add("th{");
                    lines.Add("background-color:black;");
                    lines.Add("color:white;}");
                    lines.Add("</style>");
                    lines.Add("<title>");
                    lines.Add("Tabla de Tokens");
                    lines.Add("</title>");
                    lines.Add("</head>");
                    lines.Add("<style>");
                    lines.Add("table, th, td{ border: 1px solid black; border-collapse: separate; }");
                    lines.Add("</style>");
                    lines.Add("<body>");
                    lines.Add("<h1>Tabla de Tokens</h1>");
                    lines.Add("<table>");
                    lines.Add("<tr>");
                    lines.Add("<th>" + "No." + "</th>");
                    lines.Add("<th>" + "Lexema" + "</th>");
                    lines.Add("<th>" + "Tipo" + "</th>");
                    lines.Add("</tr>");
                    foreach (Token item3 in lista)
                    {
                        lines.Add("<tr>");
                        lines.Add("<td>" + (r++) + "</td>");
                        lines.Add("<td>" + (item3.getValor()) + "</td>");
                        lines.Add("<td>" + (item3.getTipo()) + "</td>");
                        lines.Add("</tr>");
                    }
                    lines.Add("</table>");
                    lines.Add("</body>");
                    lines.Add("</html>");
                    File.WriteAllLines("TablaTokens.html", lines);
                    System.Diagnostics.Process.Start(@"../debug/TablaTokens.html");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de lectura....");
            }
            //tabla.Show();
        }
    }
}


