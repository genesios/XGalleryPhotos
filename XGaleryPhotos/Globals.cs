﻿using Xamarin.Forms;
using XGaleryPhotos.Interfaces;
using XGaleryPhotos.Models;
using XGaleryPhotos.Services;
using XGaleryPhotos.Views;
using XGaleryPhotos.ViewModels;

namespace XGaleryPhotos
{
    public static class Globals
    {
        #region Constantes

        public const string AppTitulo = "LBC APP CAPTURA DE FOTOS"; 
        public const bool DimensionesDeviceVisible = false;
        public const int FontSizeMicro = 10;
        public const bool IncluirWatermarkEnFotosGalería = false;
        public const bool IncluirWatermarkEnFotosTomadas = true;
        public const bool IncluirFechaEnWatermark = true;
        public const bool IncluirHoraEnWatermark = true;
        public const bool IncluirNombreUsuarioEnWatermark = true;
        public const bool IncluirPrefijoEnWatermark = true;
        public const int PorcentajeCompresion = 30;
        public const string PrefijoWatermark = "LBC";

        #endregion

        #region Propiedades

        public static string AppVersionName { get; set; }

        #endregion

        #region Objetos

        // Services
        public static IAuthenticateService AuthenticateService { get; set; }
        public static IMultiMediaPickerService MultiMediaPickerService { get; set; }
        public static IRepositoryService RepositoryService { get; set; }

        // Views
        public static FlujoPage FlujoPageInstance { get; set; }
        public static NavigationPage NavegacionPageInstance { get; set; }
        public static PhotoDisplayPage PhotoDisplayPageInstance { get; set; }

        // ViewModels
        public static FlujoViewModel FlujoViewModelInstance { get; set; }

        // MediaFile para info de foto
        public static MediaFile MediaFile { get; set; }

        #endregion

        static Globals()
        {
            AuthenticateService = new AuthenticateService();
            RepositoryService = new RepositoryService();
            AppVersionName = "0";
        }
    }
}
