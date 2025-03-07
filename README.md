# Specify Storage Tree Barcode Update Tool

This tool updates items’ storage location in the Specify collection database by scanning the shelf label barcode followed by scanning the barcodes of shelf items. The software remembers the last storage location until a new storage location label is scanned. The workflow affords rapid updating of the collection database in real time, as the process involves no keyboard entry or mouse use. 

## Authentication 

The application authenticates using Specify 6's user name, password, and key algorithm and authorizes that the user has preparation modify permission within the collection. Each scan updates the TimestampModified and ModifiedByAgentID for the preparation along with the storageID, so who/when is preserved at the record level.

## SafeScan

When "Verify Collection Code in Barcode" is enabled in the config, the application is considered to be in SafeScan mode and requires the Colletion Code encoded in the barcode. This prevents preparations from being accidentally scanned in the wrong collection in shelving environments where multiple collections are present.

## Label Definitions and Construction

The software operates by scanning the following types of labels:
 
- **Stationary Location (SLOC) labels** - These are for permanent fixtures and correspond to storage nodes in the Specify Storage Tree.
  - SafeScan Enabled: Encode the concatenation of SLOC, collection code and storage.storageID, E.G. **SLOCFish4236**
  - SafeScan Disabled: Encode the concatenation of SLOC and storage.storageID, E.G. **SLOC4236**
- **Movable Location (MLOC) labels** - These are for semi-permanent locations, such as vial lot containers, that correspond to storage nodes in the Specify Storage Tree and may move around. The Move Location form in the application allows you move MLOCs by scanning them to an SLOC.
  - SafeScan Enabled: Encode the concatenation of MLOC, collection code and storage.storageID, E.G. **SLOCFish4236**
  - SafeScan Disabled: Encode the concatenation of MLOC and storage.storageID, E.G. **SLOC4236**
- **Container ID (CID) labels**: These labels correspond to the ContainerID field on preparation. PrepContainerIDField has been added as config parameter in the config form to accommodate differing schemas. When a CID label is scanned, the application sets the storage location for all preparations with the scanned ContainerID. CID scanning improves workflows for tanks, large jars, and vial lots which contain multiple preps. CID labels allow for the batch assignment of prepartions to storage nodes.
  - SafeScan Enabled: Encode CID, collection code, and preparation.ContainerIDField (defined in config). E.G. **CIDFishVL-96**.
  - SafeScan Disabled: Encode CID and preparation.ContainerIDField (defined in config). E.G. **CIDVL-96**.
- **Preparation Labels** - These labels correspond to a single preparation. 
  - SafesScan Enabled: Encode the collection code and preparation.preparationId, E.G. **Fish65398**.
  - SafeScan Disabled: Encode preparation.preparationId, E.G. **65398**.

## Symbology

The application is barcode symbology agnostic as the decoding is done in the scanner and passed to the application as keyboard input. Thusly, the application may be used with your preferred symbology so long as the data encoded is as described above. 

## The Unique Constraint Problem

Guaranteed unique and immutable identifiers are required for any inventory system to be stable. The obvious choice is to use the storage and preparation primary keys within the Specify database. However, the Specify Object Relational Mapper (ORM) does not expose the primary keys within the application, meaning they are not available in the query tool or forms. Additionally, Specify does not, at the time of this release, support adding a unique constraint to an existing column on the storage or preparation tables. We tried and the application stack dumps on launch. 

To overcome these limitations, we added the ability for the software to copy the storage and preparation primary keys into fields accessible in the Specify query tool and forms. This functionality is "Update storage barcodes" and "Update prep barcodes" in the System section of the menu bar. The respective fields are defined in the application's config to accomodate differing schemas across Specify installations.

Basing the barcodes off the database level primary keys allows us ensure uniqueness. Copying the keys into fields accessible in the Specify application allows us to generate and print the barcode labels using Specify.

It is our hope Specify will eventually allow uniqueness constraints on additional storage and preparation fields so we may eliminate the update step. 

## Legacy Support

Storage Location was referred to as Shelf in previous versions of the application. Storage Location labels where referred to as Shelf Labels and used a prefix of "SHELF." 
The application is backwards compatible and will process both prefixes of "SHELF" and "SLOC" as a Storage Location.

## Rapid Proof of Concept

For rapid proof of concept testing you may use the Libre Barcode 39 Text font from https://fonts.google.com/specimen/Libre+Barcode+39+Text for label generation. Code 39 uses asterisks as start stop delimiters, which makes for easy generation. Code 39 is nearly ubiquitous with scanners which keeps things simple.

## Gratuitous Screen Shots

<img width="538" alt="LoginScreen" src="https://user-images.githubusercontent.com/81316350/146015801-38997559-b00b-404a-82b5-398cf790a6ea.png">


Scanning history may be saved to a text file by clicking the download icon on the scanning form.

<img width="638" alt="ScanningScreen" src="https://user-images.githubusercontent.com/81316350/146019316-b0def0b7-9a16-4312-bfb5-db07102c566e.png">

## Prerequisites

This software adds fuctionality to a Specify collection database and requires a working installation of the Specify Collection database on a MariaDB server. https://specifysoftware.org

## Attribution

This software was created by the [Florida Museum of Natural History Office of Museum Technology](https://www.floridamuseum.ufl.edu/omt/) The Florida Museum of Natural History is a Founding Member of Specify Collections Consortium.
