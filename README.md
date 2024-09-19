# ukag-scraper
UKAG Scraper is a tool which scrapes the entire database of airfields contained within the [UK Airfield Guide](https://www.ukairfieldguide.net/) and places them into a single KML file for viewing in Google Earth. The Guide (not affiliated in any way with this project) is a manually curated collection which aims to provide details like location and usage history for all airfields in the UK, right down to private farm strips.

When run, the program will download details of each airfield from the internet. It will then assemble them into a KML file, where each discovered airfield is given a placemark containing its name, coordinates and URL. This file is then saved as **ukag.kml** in the execution directory.

![Scraping](https://github.com/george7378/ukag-scraper/blob/main/misc/readme/1.png)
![Results](https://github.com/george7378/ukag-scraper/blob/main/misc/readme/2.png)