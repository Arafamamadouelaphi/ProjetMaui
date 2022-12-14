﻿using System;
using System.Collections.ObjectModel;
using ClassCalculateurMoyenne;
using CalculateurMapping;
using Bussness;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CalculateurApp.View;
using System.Linq;

namespace CalculateurApp.ViewModel
{
    public partial class PageAjoutMaquette : ObservableObject
    {
        public MaquetteModel maquette { get; set; }
        public Manager manager { get; set; }


        public PageAjoutMaquette()
        {
            //manager = new Manager(new MaquetteDbDataManager<CalculDbMaui>());

            

        }

        public void Init()
        {
            Items = new ObservableCollection<MaquetteModel>();
            foreach (var mm in manager.GetAllMaquette().Result)
                Items.Add(mm);
            maquette = new MaquetteModel();
        }

        [ObservableProperty]
        ObservableCollection<MaquetteModel> items;
        public string NomMaquette
        {
            get => maquette.NomMaquette;
            set => SetProperty(maquette.NomMaquette, value, maquette, (u, v) => u.setNomMaquete(v));

        }
        [RelayCommand]
        async void Add()
        {
            //Manager maquetteDbDataManager = new Manager(new MaquetteDbDataManager<CalculDbMaui>());

            if (string.IsNullOrEmpty(NomMaquette))
                return;
            MaquetteModel u = maquette;
            Items.Add(u);
            await manager.AddMaquette(maquette);
            //maquette.NomMaquette = string.Empty;
           
        }
   [RelayCommand]
        async void Delete(MaquetteModel model)

        {
         
            if (Items.Contains(model))
            {
                Items.Remove(model);
                await manager.Deletemqt(model);

                var v = await manager.GetAllMaquette();
                Console.WriteLine(v);               

            }
        }



        [RelayCommand]
        async void GetAllMaquette()
        {
            //Manager maquetteDbDataManager = new Manager(new MaquetteDbDataManager<CalculDbMaui>());

            await manager.GetAllMaquette();
        }
        [RelayCommand]
        async Task Tap(MaquetteModel maquetteName)
        {
            manager.SelectedMaquetteModel = maquetteName;
            var maquette = manager.GetMaquetteByName(maquetteName.NomMaquette);

            var parametre = new Dictionary<string, Object>
            {
                {"maquette",maquette}
            };

            await Shell.Current.GoToAsync($"{nameof(BlockView)}",parametre);
        }

    }
}
