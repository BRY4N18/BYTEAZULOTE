using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace BYTEAZULPROFESIONAL
{
    class CsEmail
    {
        string servidor;
        int puerto;
        string usuario;
        string clave;
        bool ssl;

        string de;
        string de_nombre;
        string para;
        string concopia;
        string asunto;
        string cuerpo;
        string adjunto;

        MailMessage mensaje;

        public string De
        {
            get { return de; }
            set { de = value; mensaje.From = new MailAddress(de, de_nombre); }
        }

        public string De_nombre
        {
            get { return de_nombre; }
            set { de_nombre = value; }
        }

        public string Para
        {
            get { return para; }
            set { para = value; mensaje.To.Add(new MailAddress(para)); }
        }

        public string ConCopia
        {
            get { return concopia; }
            set { concopia = value; mensaje.CC.Add(new MailAddress(concopia)); }
        }

        public string Asunto
        {
            get { return asunto; }
            set { asunto = value; mensaje.Subject = asunto; }
        }

        public string Cuerpo
        {
            get { return cuerpo; }
            set { cuerpo = value; mensaje.Body = cuerpo; }
        }

        public string Servidor
        {
            get { return servidor; }
            set { servidor = value; }
        }

        public int Puerto
        {
            get { return puerto; }
            set { puerto = value; }
        }

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }
        public bool Ssl
        {
            get { return ssl; }
            set { ssl = value; }
        }

        public CsEmail(string server, int port, bool security, string user, string pass, string name)
        {
            mensaje = new MailMessage();
            de = user;
            de_nombre = name;
            servidor = server;
            puerto = port;
            ssl = security;
            usuario = user;
            clave = pass;
            mensaje.From = new MailAddress(de, de_nombre);
        }

        public CsEmail()
        {
            mensaje = new MailMessage();
            de = "byte.azul05@gmail.com";
            de_nombre = "Factura de Byte Azul";
            servidor = "smtp.gmail.com";
            puerto = 587;
            ssl = true;
            usuario = "byte.azul05@gmail.com";
            clave = "zyjkqwouzvowmlos";
            mensaje.From = new MailAddress(de, de_nombre);
        }

        public Boolean Enviar()
        {
            SmtpClient clienteSMTP = new SmtpClient(servidor);
            clienteSMTP.Port = puerto;
            clienteSMTP.EnableSsl = ssl;
            clienteSMTP.Credentials = new NetworkCredential(usuario, clave);
            try
            {
                clienteSMTP.Send(mensaje);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                mensaje.Dispose();
                return false;
            }
            mensaje.Dispose();
            return true;
        }
    }
}
