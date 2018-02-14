# TinkrTeam_FirstTinkrBook

Steps to export original Tinkr Book and Tinkr Player to Unity 2017.3.0f3:

*For steps 3 and 4, refer to the ‘codeSnippets’ document.

1) Clone the project into your system.
2) Open the project in Unity after locating the project in the system.
3) For successful compilation, replace the obsolete functions as given below:   
    i)	Change the code in GoSpline.cs class (Compilation: 1)   
    ii)	Change the code in tk2dCamera.cs class (Compilation: 2)    
    iii)	Change the code in tk2dUpdateWindow.cs class (Compilation: 3)   
4) For successful build(webGL), do the following changes:    
    i)	Change the code blocks in SceneManagerScene23.cs class (Building:1)   
5) Navigate to Build Settings under File menu and build the project for webGL platform.
6) If your browser does not supports webGL then follow the necessary steps[1] to enable it in the specific browser.
7) Run the ‘index.html’ file, generated after the build, in a webGL supported browser.




[1] : https://superuser.com/questions/836832/how-can-i-enable-webgl-in-my-browser
