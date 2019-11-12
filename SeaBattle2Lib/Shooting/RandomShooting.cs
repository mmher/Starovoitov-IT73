﻿using System;
using SeaBattle2Lib.GameLogic;

namespace SeaBattle2Lib.Shooting
{
    public class RandomShooting : ShootingMethod
    {
        public override bool ConditionsAreMet(ref Map map)
        {
            return GetCountOfDamagedParts(ref map) == 0 && HasAFreeCell(ref map);
        }
        protected override Coordinates Shot(ref Map map, Random random)
        {
            if (random == null) random = new Random();

            while (true)
            {
                int x = random.Next(map.Width);
                int y = random.Next(map.Height);

                if (map.CellsStatuses[x, y] == CellStatus.PartOfShip || map.CellsStatuses[x, y] == CellStatus.Water)
                {
                    return new Coordinates(x,y);
                }
            }
        }
    }
}
