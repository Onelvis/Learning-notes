# Wix toolset

## Proyect templates
---
* **Setup project**: Creates a MSI file
* **Merge Module Project**: Creates a merge module `(.msm)`, which can be used to *Embed one install inside another*.
* **Setup Library Project**: Creates a WiX library `(.wixlib)`, used to share features between instalations.
* **Bootstrapper project**: Creates a `SETUP.EXE` file, instead of a MSI file.
* **Custom Action Project**: Used  to extend the functionality of the MSI installer environment with custom code that executes during an installation or repair.

---
## Installation hierarchy 
![image info](..\images\wix1.jpg)
  

---
## Components
- Fundamental building block of installations
- Contain resources (Files, registry keys, shorcuts, etc).
- Should contain only things that locally belong together
- Have an **ID** and **GUID**
- Only child must have `KeyPath="yes"`
  
![image info](..\images\wix3.jpg)

---
## Components groups
- Collect related components together
- Components and component groups are referred to in features


---
## Features
- Optional user-selectable parts of the product within the installation.
- Features refer to components and components groups via ther ID.
- **All installations have at least one feature**

![image info](..\images\wix4.JPG)
  

---
## Fragments
- Fragments can be use to delimit peaces of code.
![image info](..\images\wix5.JPG )
- Can be in differents source files
  

---
## GUIDs vs IDs
- GUIDs (**Globally unique identifier**) are used for uniquely identify **products, upgrades, etc**.
- IDs are used for identify **elements** in the WiX file and refer them somewhere else.
---
## Formats types:
1. Source files `(*.wsx)`
2. Include files `(*.wxi)`

---
## WiX Sample UI Options
- Several preconfigured UI sequences are supplied
    - WixUI_Minimal (Single dialog, welcome and license)
    - WixUI_FeatureTree (License and customize features)
    - WixUI_InstallDir (License and customize target)
    - WixUI_Mondo (License and typical, custom, complete)
    - WixUI_Advanced      (All options avaliable)

    ![image info](..\images\wix7.JPG)
    ![image info](..\images\wix8.JPG)

- Custom UI
    ![image info](..\images\wix9.JPG)

- Shorcuts
    ![image info](..\images\wix10.JPG)
    - Target: The Id that refers to the component that provides the executable, so the shorcut will refer to that executable.

- Standard Actions
    - Functionality supported by Windows Installer and WiX
    - Examples
        - InstallServices
        - StartServices
        - RegisterFonts
        - ForceReboot (during installation)
        - ScheduleReboot (after installation)
        - And many more

- Custom Actions
    - Code that executes at specific times during an installation
    - Several ways to code
    - Synergy Custom Action project template
    - Static method attributed as CustomAction



# How Tos

--- 
## Default setup project
```xml
<?xml version="1.0" encoding="UTF-8"?>

<!--Root element-->
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi">
    <Product Id="*" Name="MySetup" Language="1033" Version="1.0.0.0" Manufacturer="MyCompany" UpgradeCode="$guid3$">
        <Package InstallerVersion="200" Compressed="yes" InstallScope="perMachine" />

        <MajorUpgrade DowngradeErrorMessage="A newer version of [ProductName] is already installed." />
        <MediaTemplate />

        <Feature Id="ProductFeature" Title="MySetup" Level="1">
            <ComponentGroupRef Id="ProductComponents" />
        </Feature>
    </Product>


    <!-- Default fragment declaring hierarchy of locations -->
    <Fragment>
        <Directory Id="TARGETDIR" Name="SourceDir">
            <Directory Id="ProgramFilesFolder">
                <Directory Id="INSTALLFOLDER" Name="MySetup" />
            </Directory>
        </Directory>
    </Fragment>


    <!-- Default fragment containing the components -->
    <Fragment>
        <!-- This component is called up there in the features -->
        <ComponentGroup Id="ProductComponents" Directory="INSTALLFOLDER">
            <!-- <Component Id="ProductComponent"> -->
                <!-- TODO: Insert files, registry keys, and other resources here. -->
            <!-- </Component> -->
        </ComponentGroup>
    </Fragment>
</Wix>
```




---
## Configuring new installations
1. Initial configuration required for all installation projects
    1. Manufacturer and product names
    2. Version number
    3. Product code and upgrade code GUIDs

2. And frequently
    1. Media and packaging options 
        - Determine output format (media splitting, etc.)
        - `EmbedCab="yes"` to embed CAB file inside MSI file
    2. Customized target location

---
## Supporting Upgrades
  
![image text](..\images\wix6.jpg)
  
- Factors determining if an update is possible
    - Version string:   `Major.Minor.Build[.Revision]`
    - Product ID GUID:   Identifies a specific version of product.
    - Upgrade code GUID: Relates multiple versions together

- For an upgrade to take place
    - Product with matching upgrade code already installed.
    - Different product code.
    - Higher version number in product being installed


--- 
## Customizing the target install location - Using properties

```xml
<Fragment>
    <Directory Id="TARGETDIR" Name="SourceDir">
        <Directory Id="ProgramFilesFolder">
            <Directory Id="MANUFACTURERFOLDER" Name="!(bind.property.Manufacturer)">
                <Directory Id="INSTALLFOLDER" Name="!(bind.property.ProductName)"/>
            </Directory>
        </Directory>
    </Directory>
</Fragment>
```


---
## Installing Files
  
- Primary function of most installations
    - Files live in components
    - Components refer to a location

- Many ways to specify source, inclunding
    - Setup project folder
    - Relative path from setup project folder
    - Project reference (See code below)

- Best practice is **one file per component (best for subsequent repair)**
- `KeyPath` identifies the file used to **detect if component is installed**
- `Checksum` enables file integrity, checks for executable files.


```xml
<Component Id="File_$(var.SampleApp.TargetFileName)" Guid="{94A13ED6-8D73-4863-A45E-523F1F5A83F9}" Directory="INSTALLFOLDER">
    <File Id="File_$(var.SampleApp.TargetFileName)" KeyPath="yes" Source="$(var.SampleApp.TargetPath)" Checksum="yes">
    </File>
</Component>
```
### Example: 
``` xml
<Fragment>
		<ComponentGroup Id="ProductComponents" Directory="INSTALLFOLDER">
			<Component Id="TestWinforms.exe.config" Guid="784bff17-946e-4157-89dc-3b8ef0739135">
			  <File Id="TestWinforms.exe.config" Name="TestWinforms.exe.config" Source="$(var.TestWinforms_TargetDir)TestWinforms.exe.config" />
			</Component>
			<Component Id="TestWinforms.exe" Guid="d7c70a5f-374d-4bbf-a3c3-59c19c01b9a2">
			  <File Id="TestWinforms.exe" Name="TestWinforms.exe" Source="$(var.TestWinforms_TargetDir)TestWinforms.exe" />
			</Component>
		</ComponentGroup>
	</Fragment>
```

---
## Pre-compile .NET Assemblies
- .NET NGEN utility
    - Pre-compiles IL to native code so JIT compilation no required.
- Avaliable during installation to optimize app launch time
    - Reference optional WixNetFxExtension assembly
    - Import NetFxExtension namespace
    - Use <NativeImage> feature within <File> tag

```xml
    <Wix xlmns="http://schemas.microsoft.com/wix/2006/wi"
    xmlns:netfx="http://schemas.microsoft.com/wix/NetFxExtension">
```
```xml
    <File Id="$(var.SampleApp.TargetFileName)" KeyPath="yes" source="$(var.SampleApp.TargetPath)" Checksum="yes">
        <netfx:NativeImage Id="$(var.SampleApp.TargetFileName)" Platform="32bit" Priority="0" AppBaseDirectory="INSTALLFOLDER">
    </file>
```

---
## Defining the Execution of Custom Actions

- Schedule custom actions using `<InstallExecuteSequence>`
- **Action** refers to the ID associated with the custom action
- `After=` and `Before=` define when the custom action execute
- `NOT REMOVE="ALL"` -> Run during install
- `REMOVE="ALL"` -> Run during uninstall
    ![image info](..\images\wix11.JPG)


---
## Setting Environment Variables
```xml
<Environment Id="EnvVar_SFWINPATH" Action="set" Part="all"
Name="SFWINIPATH" Value="[DataFolder]" System="yes" Permanent="no"/>
```














