﻿using MafiaGame.Models;
using MafiaGame.Services;
using System;
using System.Web.Mvc;
using System.Windows;

namespace MafiaGame.Controllers
{
    public class MainGameController : Controller
    {
        private IPlayerService PlayerService;

        public MainGameController(IPlayerService playerService)
        {
            this.PlayerService = playerService;
        }

        //TODO: use viewmodel here
        public ActionResult Index()
        {
            PlayerEntity player = PlayerService.GetCurrent();

            ViewData["player"] = player;
            ViewData["map"] = this.CreateBasicMap();

            return View();
        }

        private Map CreateBasicMap()
        {
            Map map = new Map();
            Random random = new Random();

            int numTiles = random.Next(0, 10);
            for(int i = 0; i < numTiles; ++i)
            {
                map.TileList.Add(new Tile()
                {
                    Position = new Point(random.Next(0, 100), random.Next(0, 100))
                });
            }

            return map;
        }
    }
}