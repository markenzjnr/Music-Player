# Music Player

This C# console application allows users to manage their music library by playing, adding, updating, and deleting songs. The application imports the music files from a specified directory and stores them in a dictionary with the song title as the key and the file path as the value.

## Usage

When the application is launched, the user is presented with a menu that allows them to perform the following actions:

1. Play a song: Prompts the user to enter the title of the song they want to play. If the song exists in the music library, the application attempts to play the song using an appropriate library or process.

2. Add a song: Prompts the user to enter the title and file path of the song they want to add. If the file exists at the specified location and the song is not already in the library, the song is added to the library.

3. Update a song: Prompts the user to enter the title of the song they want to update and the new file path. If the song exists in the music library and the new file exists at the specified location, the file path for the song is updated.

4. Delete a song: Prompts the user to enter the title of the song they want to delete. If the song exists in the music library, it is removed.

5. Exit: Exits the application.

*Note: The default directory for importing music files is "C:\Users\42-DAWG\Music". If your music files are stored in a different directory, you will need to modify the value of the `directoryPath` variable in the `ImportMusic()` method.*
