# Superior Servers Spraypaint-ImportExporter
Parses Image Data From image to graffiti file and vise versa.

Useful code can be found in the [`SprayPaint`](https://github.com/InsertNameSUP/Spraypaint-ImportExporter/blob/master/SprayPaint%20ImportExport/SprayPaint.cs) class


## Methods
### `Bitmap? Import(string readFile, string outFile)`
Converts graffiti files to image files. Returns a bitmap on completion.
### `bool Export(string readFile, string outFile)`
Converts image files to graffiti files and outputs to `outFile`.
### `Bitmap? CreatePreview (ExportSetting exportSetting, string readFile)`
Converts graffiti files to bitmap but does not save image. Returns a bitmap on completion (or null on error).
