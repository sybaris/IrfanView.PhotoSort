# IrfanView.PhotoSort
Extension to help you to sort photos using IrfanView.
  
## Key Features  
- Navigate through your photo collection using IrfanView and move the photo (until selected) to a new folder. A popup will ask you for the name of the folder, adding date of the first photo as a prefix
  
## How to install
- Download Latest release of IrfanView.PhotoSort
- Unzip all files in a folder (note this folder, you will need it later)
- Open IrfanView
- Select "Options"
- Select "Properties/Settings..."
![alt text](https://github.com/Sybaris/IrfanView.PhotoSort/docs/IrfanViewConfig1.jpg)
- Select "Miscellaneous"
- On "Set external editors" (number 1) setup the extension with the following texte : D:\...\Sybaris.Irfanview.Extensions.FolderRenamer.exe "RenameFolder --CurrentPictureFileName="%1""
- Replace "D:\..." by the folder where you have copied the release files of IrfanView.PhotoSort.
![alt text](https://github.com/Sybaris/IrfanView.PhotoSort/docs/IrfanViewConfig2.jpg)
  
## How it works
- Open a folder that contains photos
- Open the first a photo with IrfanView
- Navigate to the next photos until the lastest photo of this album
- Use the shortcut SHIFT+1
- A popup will ask you for the name of the folder
![alt text](https://github.com/Sybaris/IrfanView.PhotoSort/docs/IrfanView.PhotoSort.Run.jpg)

