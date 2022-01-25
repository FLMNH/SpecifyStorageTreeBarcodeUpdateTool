Specify Storage Tree Barcode Update Tool

This tool updates items’ storage location in the Specify collection database by scanning the shelf label barcode 
followed by scanning the barcodes of shelf items. The software remembers the last shelf until a new 
shelf label is scanned. The workflow affords rapid updating of the collection database in real time, as the process involves 
no keyboard entry or mouse use. 

The application authenticates using Specify 6's user name, password, and key algorithm and authorizes that the user
has preparation modify permission within the collection. Each scan updates the TimestampModified and ModifiedByAgentID
for the preparation along with the storageID, so who/when is preserved at the record level.

Shelf labels are the storage.storageID prefixed with "SHELF" and preparation labels are preparation.PreparationID. The application
is barcode symbology agnostic as the decoding is done in the scanner and passed to the application as keyboard input. Thusly,
the application may be used with your preferred symbology so long as the data encoded is as described above. 

For rapid proof of concept testing you may use the Libre Barcode 39 Text font from https://fonts.google.com/specimen/Libre+Barcode+39+Text for label generation. Code 39 uses asterisks as start stop delimiters, which makes for easy generation. Code 39 is nearly ubiquitous with
scanners which keeps things simple.

<img width="538" alt="LoginScreen" src="https://user-images.githubusercontent.com/81316350/146015801-38997559-b00b-404a-82b5-398cf790a6ea.png">


Scanning history may be saved to a text file by clicking the download icon on the scanning form.

<img width="638" alt="ScanningScreen" src="https://user-images.githubusercontent.com/81316350/146019316-b0def0b7-9a16-4312-bfb5-db07102c566e.png">

This software adds fuctionality to a Specify collection database and requires a working installation of the Specify Collection database on
a MySQL server. https://specifysoftware.org

The Florida Museum of Natural History is a Founding Member of Specify Collections Consortium.

This software was created by the [Florida Museum of Natural History Office of Museum Technology](https://www.floridamuseum.ufl.edu/omt/)
