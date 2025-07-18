READING-IMAGE-LINES Application
==============================

Description:
------------
This console application counts the number of vertical black lines in a black and white image created using MS Paint.

Usage:
------
Run the application from the command line:
reading-image-lines.exe <absolute_image_path>

Example:
reading-image-lines.exe C:\[ROOT_FOLDER]\reading-image-lines\images\img_1.jpg 

Requirements:
-------------
- The input image must be a .jpg file.
- Lines must be perfectly vertical, created using the bucket tool in MS Paint on a white background.

Error Handling:
---------------
- If no argument or more than one argument is provided, an error message is displayed.
- If the file does not exist, an error message is displayed.
- All exceptions are caught and displayed without crashing the application.

Notes:
------
- The algorithm scans each column of the image and identifies columns that contain black pixels.
- Consecutive black columns are counted as a single vertical line.

Author:
-------
Alexandre Gavazza