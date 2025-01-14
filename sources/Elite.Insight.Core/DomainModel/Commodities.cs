﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Elite.Insight.Core.Helpers;

namespace Elite.Insight.Core.DomainModel
{
	public class Commodities: IReadOnlyCollection<Commodity>
	{
		private readonly CommodityCollection _commodities;

		private readonly ILocalizer _localization;

		public Commodities(ILocalizer localizer)
		{
			if (localizer == null)
			{
				throw new ArgumentNullException("localizer");
			}
			_commodities = new CommodityCollection();
			_localization = localizer;
		}

		protected class CommodityCollection : KeyedCollection<string, Commodity>
		{
			protected override string GetKeyForItem(Commodity item)
			{
				return item.Name.ToCleanTitleCase();
			}

			public bool TryGetValue(string commodityName, out Commodity commodity)
			{
				if (Dictionary != null && Dictionary.TryGetValue(commodityName, out commodity))
				{
					return true;
				}
				else
				{
					commodity = null;
					return false;
				}
			}
		}

		public Commodity this[string commodityName]
		{
			get { return _commodities[commodityName]; }
		}

		public Commodity TryGet(string commodityName)
		{
			Commodity commodity;
			_commodities.TryGetValue(GetBasename(commodityName.ToCleanTitleCase()), out commodity);
			return commodity;
		}

		public IEnumerator<Commodity> GetEnumerator()
		{
			return _commodities.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(Commodity item)
		{
			_commodities.Add(item);
		}

		public void Clear()
		{
			_commodities.Clear();
		}

		public bool Contains(Commodity item)
		{
			return _commodities.Contains(item);
		}

		public bool Remove(Commodity item)
		{
			return _commodities.Remove(item);
		}

		public int Count { get { return _commodities.Count; } }

		public void Update(Commodity commodity)
		{
			string basename = GetBasename(commodity.Name);
			if (String.IsNullOrEmpty(basename))
			{
				Trace.TraceWarning("unknown commodity " + commodity);
				return;
			}
			commodity.Name = basename;
			commodity.LocalizedName = _localization.TranslateToCurrent(commodity.Name);
			Commodity existingCommodity;
			if (!_commodities.TryGetValue(commodity.Name, out existingCommodity))
			{
				Add(commodity);
			}
			else
			{
				existingCommodity.UpdateFrom(commodity, UpdateMode.Update);
			}
		}

		public void Save(string filepath, bool backupPrevious)
		{
			this.WriteTo(new FileInfo(filepath), backupPrevious);
		}

		public string GetBasename(string commodityName)
		{
			return _localization.TranslateInEnglish(commodityName);
		}
	}
}