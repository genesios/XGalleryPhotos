﻿using System.Collections.Generic;
using XWebServices.Interfaces;

namespace XWebServices
{
    public class WbsFotosUpdate
    {
        public IXWebService WebService { get; set; }

        public WbsFotosUpdate(IXWebService webService)
        {
            WebService = webService;
        }

        public bool UpdateFotos(string flujoNro, string tipoDocumento, int nroRC,
                                    string usuarioSistema, string extensionArchivo, string sistemaOrigen,
                                    params string[] images64)
        {
            if (WebService == null)
                return false;

            WebService.RequestUri = @"http://desanilus.lbc.bo/Nilus/WsOnbase/OnBaseWS.asmx";
            WebService.SoapAction = "http://tempuri.org/ImportarDocumento";
            WebService.WebMethod = "ImportarDocumento";
            WebService.WebNamespace = "http://tempuri.org/";

            //string stringFotos = string.Empty;
            //if (images64 != null && images64.Length > 0)
            //{
            //    foreach (string foto in images64)
            //        stringFotos += $"<string>{foto}</string>";
            //}
            //else
            //    stringFotos = $"string:{string.Empty}";

            List<string> parametros = new List<string>()
            {
                "<documento>",
                                        $"nroSolicitud:{flujoNro}",
                                        $"tipoDocumento:{tipoDocumento}",
                                        $"extensionArchivo:{extensionArchivo}",
                                        "<keywords>",
                                            "<KeywordOnBaseEntity>",
                                                //$"idKeywords:{string.Empty}",
                                                $"nombre:LBC UserName WS",
                                                $"valor:{usuarioSistema}",
                                            "</KeywordOnBaseEntity>",
                                            "<KeywordOnBaseEntity>",
                                                //$"idKeywords:{string.Empty}",
                                                $"nombre:No. de RC",
                                                $"valor:{nroRC}",
                                            "</KeywordOnBaseEntity>",
                                        "</keywords>",
                                    "</documento>",
                                    "<archivosBase64>"
            };
            if (images64 != null && images64.Length > 0)
            {
                foreach (string image in images64)
                    parametros.Add($"string:{image}");
            }
            else
            {
                parametros.Add($"string:{string.Empty}");
            }

            parametros.Add("</archivosBase64>");
            parametros.Add($"SistemaOrigen:{sistemaOrigen}");

            //Dictionary<string, object> fields =
            //WebService.Invoke(  "<documento>",
            //                        $"nroSolicitud:{flujoNro}",
            //                        $"tipoDocumento:{tipoDocumento}",
            //                        $"extensionArchivo:{extensionArchivo}",
            //                        "<keywords>",
            //                            "<KeywordOnBaseEntity>",
            //                                //$"idKeywords:{string.Empty}",
            //                                $"nombre:LBC UserName WS",
            //                                $"valor:{usuarioSistema}",
            //                            "</KeywordOnBaseEntity>",
            //                            "<KeywordOnBaseEntity>",
            //                                //$"idKeywords:{string.Empty}",
            //                                $"nombre:No. de RC",
            //                                $"valor:{nroRC}",
            //                            "</KeywordOnBaseEntity>",
            //                        "</keywords>",
            //                    "</documento>",
            //                    "<archivosBase64>",
            //                        stringFotos,
            //                    "</archivosBase64>",
            //                    $"SistemaOrigen:{sistemaOrigen}");

            Dictionary<string, object> fields = WebService.Invoke(parametros.ToArray());

            if (fields == null || fields.Count == 0)
                return false;

            string mensaje = string.Empty;
            bool esvalido = false;

            foreach (var field in fields)
            {
                if (field.Key == "Mensaje" && field.Value != null)
                    mensaje = (string)field.Value;
                if (field.Key == "EsValido")
                    esvalido = field.Value != null && ((string)field.Value).ToLower() == "true";
            }
            return esvalido;
        }
    }
}
