﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RegulatedNoise.EDDB_Data.CommoditiesJsonTypes;
using RegulatedNoise.Enums_and_Utility_Classes;

namespace RegulatedNoise.EDDB_Data
{

    public class EDStation
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("system_id")]
        public int SystemId { get; set; }

        [JsonProperty("max_landing_pad_size")]
        public string MaxLandingPadSize { get; set; }

        [JsonProperty("distance_to_star")]
        public int? DistanceToStar { get; set; }

        [JsonProperty("faction")]
        public string Faction { get; set; }

        [JsonProperty("government")]
        public string Government { get; set; }

        [JsonProperty("allegiance")]
        public string Allegiance { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("has_blackmarket")]
        public int? HasBlackmarket { get; set; }

        [JsonProperty("has_commodities")]
        public int? HasCommodities { get; set; }

        [JsonProperty("has_refuel")]
        public int? HasRefuel { get; set; }

        [JsonProperty("has_repair")]
        public int? HasRepair { get; set; }

        [JsonProperty("has_rearm")]
        public int? HasRearm { get; set; }

        [JsonProperty("has_outfitting")]
        public int? HasOutfitting { get; set; }

        [JsonProperty("has_shipyard")]
        public int? HasShipyard { get; set; }

        [JsonProperty("import_commodities")]
        public string[] ImportCommodities { get; set; }

        [JsonProperty("export_commodities")]
        public string[] ExportCommodities { get; set; }

        [JsonProperty("prohibited_commodities")]
        public string[] ProhibitedCommodities { get; set; }

        [JsonProperty("economies")]
        public string[] Economies { get; set; }

        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty("listings")]
        public EDMarketData[] EdMarketDatas { get; set; }

         /// <summary>
         /// creates a new station 
         /// </summary>
        public EDStation()
        {
            clear();
        }

        /// <summary>
         /// creates a new station as a copy of another station
         /// only Id and SystemID must declared extra
         /// </summary>
         /// <param name="newId"></param>
         /// <param name="sourceSystemID"></param>
         /// <param name="sourceStation"></param>
        public EDStation(int newId, int sourceSystemID, EDStation sourceStation)
        {
            clear();

            Id              = newId;
            SystemId        = sourceSystemID;
            getValues(sourceStation);   
        }

        public void clear()
        {
            Id                    = 0;
            SystemId              = 0;
            Name                  = string.Empty;
            MaxLandingPadSize     = null;
            DistanceToStar        = null;
            Faction               = null;
            Government            = null;
            Allegiance            = null;
            State                 = null;
            Type                  = null;
            HasBlackmarket        = null;
            HasCommodities        = null;
            HasRefuel             = null;
            HasRepair             = null;
            HasRearm              = null;
            HasOutfitting         = null;
            HasShipyard           = null;

            ImportCommodities     = new String[0];
            ExportCommodities     = new String[0];
            ProhibitedCommodities = new String[0];
            Economies             = new String[0];
        }

        /// <summary>
        /// true, if all data *except the two IDs* is equal (case insensitive)
        /// </summary>
        /// <param name="eqSystem"></param>
        /// <returns></returns>
        public bool EqualsED(EDStation eqStation)
        {
            bool retValue = false;

            if(eqStation != null)
            {


                if (ObjectCompare.EqualsNullable(this.Name, eqStation.Name) &&
                    ObjectCompare.EqualsNullable(this.MaxLandingPadSize, eqStation.MaxLandingPadSize) && 
                    ObjectCompare.EqualsNullable(this.DistanceToStar, eqStation.DistanceToStar) && 
                    ObjectCompare.EqualsNullable(this.Faction, eqStation.Faction) && 
                    ObjectCompare.EqualsNullable(this.Government, eqStation.Government) && 
                    ObjectCompare.EqualsNullable(this.Allegiance, eqStation.Allegiance) && 
                    ObjectCompare.EqualsNullable(this.State, eqStation.State) && 
                    ObjectCompare.EqualsNullable(this.Type, eqStation.Type) && 
                    ObjectCompare.EqualsNullable(this.HasBlackmarket, eqStation.HasBlackmarket) && 
                    ObjectCompare.EqualsNullable(this.HasCommodities, eqStation.HasCommodities) && 
                    ObjectCompare.EqualsNullable(this.HasRefuel, eqStation.HasRefuel) &&
                    ObjectCompare.EqualsNullable(this.HasRepair, eqStation.HasRepair) && 
                    ObjectCompare.EqualsNullable(this.HasRearm, eqStation.HasRearm) &&
                    ObjectCompare.EqualsNullable(this.HasOutfitting, eqStation.HasOutfitting) &&
                    ObjectCompare.EqualsNullable(this.HasShipyard, eqStation.HasShipyard) &&
                    ObjectCompare.EqualsNullable(this.ImportCommodities, eqStation.ImportCommodities) &&
                    ObjectCompare.EqualsNullable(this.ExportCommodities, eqStation.ExportCommodities) &&
                    ObjectCompare.EqualsNullable(this.ProhibitedCommodities, eqStation.ProhibitedCommodities) &&
                    ObjectCompare.EqualsNullable(this.Economies, eqStation.Economies))
                        retValue = true;

            }

            return retValue;             
        }

        /// <summary>
        /// copy the values from another station exept for the ID
        /// </summary>
        /// <param name="ValueStation"></param>
        public void getValues(EDStation ValueStation, bool getAll = false)
        {
            if (getAll)
            {
                Id          = ValueStation.Id;
                SystemId    = ValueStation.SystemId;
            }

            Name                  = ValueStation.Name;
            MaxLandingPadSize     = ValueStation.MaxLandingPadSize;
            DistanceToStar        = ValueStation.DistanceToStar;
            Faction               = ValueStation.Faction;
            Government            = ValueStation.Government;
            Allegiance            = ValueStation.Allegiance;
            State                 = ValueStation.State;
            Type                  = ValueStation.Type;
            HasBlackmarket        = ValueStation.HasBlackmarket;
            HasCommodities        = ValueStation.HasCommodities;
            HasRefuel             = ValueStation.HasRefuel;
            HasRepair             = ValueStation.HasRepair;
            HasRearm              = ValueStation.HasRearm;
            HasOutfitting         = ValueStation.HasOutfitting;
            HasShipyard           = ValueStation.HasShipyard;

            ImportCommodities     = ValueStation.ImportCommodities.CloneN();
            ExportCommodities     = ValueStation.ExportCommodities.CloneN();
            ProhibitedCommodities = ValueStation.ProhibitedCommodities.CloneN();
            Economies             = ValueStation.Economies.CloneN();

        }

    }

}