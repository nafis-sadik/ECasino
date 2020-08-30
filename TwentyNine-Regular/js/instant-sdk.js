FBInstant.initializeAsync()
.then(() => {
    let progress = 0;
    let interval = setInterval(() => {
        progress += 3;
        FBInstant.setLoadingProgress(progress);
        if(progress >= 99){
            clearInterval(interval);
            StartGame();
        }
    }, 50);
});

let StartGame = () => {
    FBInstant.startGameAsync()
    .then(() => {
        let ContextId = FBInstant.context.getID();
        let ContextType = FBInstant.context.getType();
      
        let PlayerName = FBInstant.player.getName();
        let PlayerPic = FBInstant.player.getPhoto();
        let PlayerId = FBInstant.player.getID();

        let currentPlayer = new Player(ContextId, ContextType, PlayerName, PlayerPic, PlayerId);
        appStart(currentPlayer);
        game.start();
    }); 
}