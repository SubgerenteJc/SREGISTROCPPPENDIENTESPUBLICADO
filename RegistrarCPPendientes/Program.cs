using Newtonsoft.Json;
using RegistrarCPPendientes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarCPPendientes
{
    internal class Program
    {
        public static FacLabControler facLabControler = new FacLabControler();
        static void Main(string[] args)
        {
            Program muobject = new Program();

            //FUNCION PARA INSERTAR INFO EN VISTACARTAPORTE SI NO ESTA REISTRADA
            string cpfolio = "1312256";
           
                var request7 = (HttpWebRequest)WebRequest.Create("https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/cfdis?folioEspecifico=" + cpfolio);
                var response7 = (HttpWebResponse)request7.GetResponse();
                var responseString7 = new StreamReader(response7.GetResponseStream()).ReadToEnd();

                List<ModelFact> separados7 = JsonConvert.DeserializeObject<List<ModelFact>>(responseString7);

                if (separados7 != null)
                {
                    foreach (var elem in separados7)

                    {
                        string Serie = elem.serie;
                        if (Serie != "TDRT" || Serie != "NCT")
                        {
                            string Folio = cpfolio;

                            string UUID = elem.uuid;
                            string Pdf_xml_descarga = elem.pdfAndXmlDownload;
                            string Pdf_descargaFactura = "https://canal1.xsa.com.mx:9050" + elem.pdfDownload;
                            string xlm_descargaFactura = "https://canal1.xsa.com.mx:9050" + elem.xmlDownload;
                            string cancelFactura = "";
                            string LegNum = cpfolio;
                            string Fecha = elem.fecha;
                            string Total = elem.monto;
                            string Moneda = elem.tipoMoneda;
                            string RFC = elem.rfc;
                            string Origen = "0";
                            string Destino = "";

                            facLabControler.insertfaltantes(Folio, Serie, UUID, Pdf_xml_descarga, Pdf_descargaFactura, xlm_descargaFactura, cancelFactura, LegNum, Fecha, Total, Moneda, RFC, Origen, Destino);
                        }

                    }
                }
            

            ///
            //DataTable tbl = facLabControler.GetLeg();
            //if (tbl.Rows.Count > 0)
            //{
            //    foreach (DataRow list in tbl.Rows)
            //    {
            //        string cpfolio = list["segmento"].ToString();
            //        DataTable resul = facLabControler.ExisteSegmento(cpfolio);
            //        if (resul.Rows.Count < 1)
            //        {
            //            var request7 = (HttpWebRequest)WebRequest.Create("https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/cfdis?folioEspecifico=" + cpfolio);
            //            var response7 = (HttpWebResponse)request7.GetResponse();
            //            var responseString7 = new StreamReader(response7.GetResponseStream()).ReadToEnd();

            //            List<ModelFact> separados7 = JsonConvert.DeserializeObject<List<ModelFact>>(responseString7);

            //            if (separados7 != null)
            //            {
            //                foreach (var elem in separados7)
                                
            //                {
            //                    string Serie = elem.serie;
            //                    if (Serie != "TDRT" || Serie != "NCT")
            //                    {
            //                        string Folio = cpfolio;

            //                        string UUID = elem.uuid;
            //                        string Pdf_xml_descarga = elem.pdfAndXmlDownload;
            //                        string Pdf_descargaFactura = "https://canal1.xsa.com.mx:9050" + elem.pdfDownload;
            //                        string xlm_descargaFactura = "https://canal1.xsa.com.mx:9050" + elem.xmlDownload;
            //                        string cancelFactura = "";
            //                        string LegNum = cpfolio;
            //                        string Fecha = elem.fecha;
            //                        string Total = elem.monto;
            //                        string Moneda = elem.tipoMoneda;
            //                        string RFC = elem.rfc;
            //                        string Origen = "0";
            //                        string Destino = "";

            //                        facLabControler.insertfaltantes(Folio, Serie, UUID, Pdf_xml_descarga, Pdf_descargaFactura, xlm_descargaFactura, cancelFactura, LegNum, Fecha, Total, Moneda, RFC, Origen, Destino);
            //                    }
                                
            //                }
            //            }
            //        }
            //    }
            //}

            //FIN FUNCION
        }
    }
}
