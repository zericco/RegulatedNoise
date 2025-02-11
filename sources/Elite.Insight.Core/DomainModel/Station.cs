﻿using System;
using System.Linq;
using Elite.Insight.Annotations;
using Elite.Insight.Core.Helpers;
using Newtonsoft.Json;

namespace Elite.Insight.Core.DomainModel
{
	public class Station : UpdatableEntity
	{
		private string _name;

		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("name")]
		public string Name
		{
			get { return _name; }
			private set { _name = value.ToCleanTitleCase(); }
		}

		[JsonProperty("system")]
		public string SystemName { get; set; }

		[JsonIgnore]
		public long SystemId { get; set; }

		[JsonProperty("max_landing_pad_size")]
		public LandingPadSize? MaxLandingPadSize { get; set; }

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
		public bool? HasBlackmarket { get; set; }

		[JsonProperty("has_commodities")]
		public bool? HasCommodities { get; set; }

		[JsonProperty("has_refuel")]
		public bool? HasRefuel { get; set; }

		[JsonProperty("has_repair")]
		public bool? HasRepair { get; set; }

		[JsonProperty("has_rearm")]
		public bool? HasRearm { get; set; }

		[JsonProperty("has_outfitting")]
		public bool? HasOutfitting { get; set; }

		[JsonProperty("has_shipyard")]
		public bool? HasShipyard { get; set; }

		[JsonProperty("available_ships")]
		public string[] AvailableShips { get; set; }

		[JsonProperty("import_commodities")]
		public string[] ImportCommodities { get; set; }

		[JsonProperty("export_commodities")]
		public string[] ExportCommodities { get; set; }

		[JsonProperty("prohibited_commodities")]
		public string[] ProhibitedCommodities { get; set; }

		[JsonProperty("economies")]
		public string[] Economies { get; set; }

		[JsonProperty("updated_at")]
		public long UpdatedAt { get; set; }

		/// <summary>
		/// creates a new station 
		/// </summary>
		protected Station()
		{
			Name = string.Empty;
			ImportCommodities = new String[0];
			ExportCommodities = new String[0];
			ProhibitedCommodities = new String[0];
			Economies = new String[0];
		}

		public Station([NotNull] string name)
			: this()
		{
			if (String.IsNullOrWhiteSpace(name)) throw new ArgumentException("invalid station name", "name");
			Name = name;
		}

		/// <summary>
		/// copy the values from another station exept for the ID
		/// </summary>
		/// <param name="source">The source.</param>
		/// <param name="updateMode">The update mode.</param>
		public void UpdateFrom(Station source, UpdateMode updateMode)
		{
			bool doCopy = updateMode == UpdateMode.Clone || updateMode == UpdateMode.Copy;
			bool isNewer = UpdatedAt < source.UpdatedAt;
			if (updateMode == UpdateMode.Clone)
			{
				Name = source.Name;
			}

			if (doCopy || !MaxLandingPadSize.HasValue || (isNewer && source.MaxLandingPadSize.HasValue))
				MaxLandingPadSize = source.MaxLandingPadSize;
			if (doCopy || !DistanceToStar.HasValue || (isNewer && source.DistanceToStar.HasValue))
				DistanceToStar = source.DistanceToStar;
			if (doCopy || String.IsNullOrEmpty(Faction) || (isNewer && !String.IsNullOrEmpty(source.Faction)))
				Faction = source.Faction;
			if (doCopy || String.IsNullOrEmpty(Government) || (isNewer && !String.IsNullOrEmpty(source.Government)))
				Government = source.Government;
			if (doCopy || String.IsNullOrEmpty(Allegiance) || (isNewer && !String.IsNullOrEmpty(source.Allegiance)))
				Allegiance = source.Allegiance;
			if (doCopy || String.IsNullOrEmpty(State) || (isNewer && !String.IsNullOrEmpty(source.State)))
				State = source.State;
			if (doCopy || String.IsNullOrEmpty(Type) || (isNewer && !String.IsNullOrEmpty(source.Type)))
				Type = source.Type;
			if (doCopy || !HasBlackmarket.HasValue || (isNewer && source.HasBlackmarket.HasValue))
				HasBlackmarket = source.HasBlackmarket;
			if (doCopy || !HasCommodities.HasValue || (isNewer && source.HasCommodities.HasValue))
				HasCommodities = source.HasCommodities;
			if (doCopy || !HasRefuel.HasValue || (isNewer && source.HasRefuel.HasValue))
				HasRefuel = source.HasRefuel;
			if (doCopy || !HasRepair.HasValue || (isNewer && source.HasRepair.HasValue))
				HasRepair = source.HasRepair;
			if (doCopy || !HasRearm.HasValue || (isNewer && source.HasRearm.HasValue))
				HasRearm = source.HasRearm;
			if (doCopy || !HasOutfitting.HasValue || (isNewer && source.HasOutfitting.HasValue))
				HasOutfitting = source.HasOutfitting;
			if (doCopy || !HasShipyard.HasValue || (isNewer && source.HasShipyard.HasValue))
				HasShipyard = source.HasShipyard;

			if (isNewer || updateMode == UpdateMode.Clone || updateMode == UpdateMode.Copy)
			{
				ImportCommodities = source.ImportCommodities.CloneN();
				ExportCommodities = source.ExportCommodities.CloneN();
				ProhibitedCommodities = source.ProhibitedCommodities.CloneN();
				Economies = source.Economies.CloneN();
				AvailableShips = source.AvailableShips.CloneN();
			}
			else if (updateMode == UpdateMode.Update)
			{
				if (source.ImportCommodities != null)
					ImportCommodities = ImportCommodities.Union(source.ImportCommodities).Distinct().ToArray();
				if (source.ExportCommodities != null)
					ExportCommodities = ExportCommodities.Union(source.ExportCommodities).Distinct().ToArray();
				if (source.ProhibitedCommodities != null)
					ProhibitedCommodities = ProhibitedCommodities.Union(source.ProhibitedCommodities).Distinct().ToArray();
				if (source.Economies != null)
					Economies = Economies.Union(source.Economies).Distinct().ToArray();
				if (source.AvailableShips != null)
					AvailableShips = AvailableShips.Union(source.AvailableShips).Distinct().ToArray();
			}

			if (doCopy || UpdatedAt == 0 || isNewer)
				UpdatedAt = source.UpdatedAt;
			base.UpdateFrom(source, updateMode);
		}

		public override string ToString()
		{
			return Name + " [" + SystemName + "]";
		}
	}

	public enum LandingPadSize
	{
		M,
		L
	}
}
