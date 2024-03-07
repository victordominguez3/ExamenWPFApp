using CommunityToolkit.Mvvm.ComponentModel;
using ExamenWPFApp.Core;
using ExamenWPFApp.Models;
using ExamenWPFApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExamenWPFApp
{
    public partial class MainViewModel: ObservableObject
    {

        MiHttpClient http = new MiHttpClient();

        [ObservableProperty]
        ObservableCollection<Artista> _artistas;

        private Artista? _artistaSeleccionado;
        public Artista? ArtistaSeleccionado
        {
            get { return _artistaSeleccionado; }
            set
            {
                if (_artistaSeleccionado != value)
                {
                    _artistaSeleccionado = value;
                    OnPropertyChanged(nameof(ArtistaSeleccionado));
                }
            }
        }

        List<Pintura> allPinturas;

        [ObservableProperty]
        ObservableCollection<Pintura> _pinturas;

        private Pintura? _pinturaSeleccionada;
        public Pintura? PinturaSeleccionada
        {
            get { return _pinturaSeleccionada; }
            set
            {
                if (_pinturaSeleccionada != value)
                {
                    _pinturaSeleccionada = value;
                    OnPropertyChanged(nameof(PinturaSeleccionada));
                }
            }
        }

        public RelayCommand SeleccionarPinturaCommand { get; set; }

        public RelayCommand FiltroButtonCommand { get; set; }

        public MainViewModel()
        {
            allPinturas = new List<Pintura>();
            _artistas = new ObservableCollection<Artista>();
            _pinturas = new ObservableCollection<Pintura>();
            GetArtistas();
            GetPinturas();
            SeleccionarPinturaCommand = new RelayCommand(SeleccionarPintura);
            FiltroButtonCommand = new RelayCommand(FiltrarPinturas);
        }


        private async void GetArtistas()
        {
            List<Artista> items = new List<Artista>();

            items = await http.GetDataAsync<Artista>("http://192.168.16.117:7777/artists/");
            
            foreach (Artista a in items)
            {
                _artistas.Add(a);
            }
        }

        private async void GetPinturas()
        {

            List<Pintura> items = new List<Pintura>();

            items = await http.GetDataAsync<Pintura>("http://192.168.16.117:7777/images/");

            foreach (Pintura a in items)
            {
                a.File = "http://192.168.16.117:7777" + a.File;
                allPinturas.Add(a);
                _pinturas.Add(a);
            }

        }

        private void SeleccionarPintura(object? obj)
        {
            if (obj is Pintura pintura)
            {
                PinturaSeleccionada = pintura;
            }
        }

        private void FiltrarPinturas(object? obj)
        {
            if (_artistaSeleccionado != null)
            {
                _pinturas.Clear();

                foreach (Pintura p in allPinturas)
                {
                    if (p.Artist.Name == _artistaSeleccionado.Name)
                    {
                        _pinturas.Add(p);
                    }
                }
            }
            
        }

    }
}
