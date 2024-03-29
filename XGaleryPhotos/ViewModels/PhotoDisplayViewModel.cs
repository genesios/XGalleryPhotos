﻿using System;
using System.Windows.Input;
using Xamarin.Forms;
using XGaleryPhotos.Interfaces;
using XGaleryPhotos.Models;

namespace XGaleryPhotos.ViewModels
{
    public class PhotoDisplayViewModel
    {
        public ICommand RegresarCommand { get; set; }
        public ICommand EliminarFotoCommand { get; set; }
        public MediaFile MediaFile { get ; set; }

        public PhotoDisplayViewModel()
        {
            RegresarCommand = new Command(() =>
            {
                Globals.NavegacionPageInstance.PopAsync();
            });

            EliminarFotoCommand = new Command(() =>
            {
                MediaFile = Globals.RepositoryService.GetMediaFile();

                var media = Globals.FlujoViewModelInstance.Media;
                int i;
                for (i = 0; i < media.Count; i++)
                {
                    if (MediaFile.Id == media[i].Id)
                        break;
                }
                media.RemoveAt(i);

                Globals.NavegacionPageInstance.PopAsync();
            });

        }
    }
}
