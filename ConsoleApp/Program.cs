﻿using Business;
using ConsoleApp.Data;
using ConsoleApp.Interfaces;
using Data;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        internal static Context Context { get; private set; }

        internal static FilmographyService Service { get; private set; }

        internal static Menu MainMenu { get; private set; }

        static void Main(string[] args)
        {
            Context = new Context();
            IDataSeeder seeder = new DataSeeder(Context);
            seeder.SeedData();
            Service = new FilmographyService(Context);
            IEnumerable<(string, Action)> mainMenuItems = new List<(string, Action)>()
            {
                ("Get all actors. Sort by full name, then - year of birth", QueriesPrinter.GetActors),
                ("Get all films starting from any year. Sort by year descending, then by name ascending", 
                QueriesPrinter.GetMoviesFromYear),
                ("Get all films and spectacles where actor starred. Sort by: name", 
                QueriesPrinter.GetActorPerformances),
                ("Get all actors joined with their roles, then with films/spectacles", 
                QueriesPrinter.GetActorsWithFilmography),
                ("Get the cast of the spectacle. sort by: type of the role", QueriesPrinter.GetSpectacleCast),
                ("Get movies grouped by genres. Sort by name of the genre", QueriesPrinter.GetMoviesGroupedByGenres),
                ("Get top-N actors. Sort by quantity of main roles both in movies and speactacles.", 
                QueriesPrinter.GetTopMainRolesPopularActors),
                ("Find actors by fullname", QueriesPrinter.FindActorByName),
                ("Get genres that were used both in movies and spectacles", QueriesPrinter.GetUniversalGenres),
                ("Get all actors that are directors too. Sort by year of birth", 
                QueriesPrinter.GetActorsDirectors),
                ("Get all actors that starred in at least one movie or spectacle with given genre. " +
                "Sort by fullname, then - year of birth", QueriesPrinter.GetActorsByGenre),
                ("Find films by director's full name. Sort by film year descending", 
                QueriesPrinter.FindMoviesByDirectorName),
                ("Find all films and spectacles by name. Group by type - spectacle or movie", 
                QueriesPrinter.FindPerformancesByName),
                ("Get genres with quantity of movies and spectacles of them. " +
                "Sort by quantity of movies desc., then - spectacles desc.", QueriesPrinter.GetGenresStats),
                ("Find spectacles of genre by start of the name", QueriesPrinter.FindSpectaclesByGenreNameStart)
            };
            MainMenu = new Menu
            {
                Header = "22. Actors and their filmographies\n" +
                "Kvasha Vladislav, IK-93",
                Name = "query",
                Items = mainMenuItems
            };
            MainMenu.Print();
            Console.ResetColor();
        }
    }
}
