#Elite Insight

##Elite dangerous companion, swiss knife which help you find anything and communicate with eddn.

==============
- provide system and station data
- import market prices from various sources (EDDB, Trade Dangerous, local files)
- export market data to CSV.
- Trading Tool
  filter Market prices according to many criteria
    distance to current system
    station distance from system
    station allegiance, economy, ...
- EDDN Communication
  listen to EDDN for up-to-date prices
    export prices to EDDN
- Commanders Log (inherited from [https://github.com/Duke-Jones/RegulatedNoise/releases](RegulatedNoise)) (needs log activation)
  watch Elite logs to retrieve pilot name and location
- built-in, quick OCR (inherited from [https://github.com/seeebek/EliteOCR](Elite-OCR))
  allow to read Elite Dangerous screen and import market prices into Elite Insight 
- plausibilitycheck imported market prices ((inherited from [https://github.com/Duke-Jones/RegulatedNoise/releases](RegulatedNoise))
  imported market prices are first analyzed, invalid data are discarded
