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
        Player.contextId = FBInstant.context.getID().toString();
        Player.contextType = FBInstant.context.getType().toString();
        Player.playerName = FBInstant.player.getName().toString();
        Player.playerPic = FBInstant.player.getPhoto().toString();
        Player.playerId = FBInstant.player.getID().toString();
        console.log('test');
        console.log(FBInstant.player.getID().toString());
        console.log(Player.playerId);
        appStart();
        game.start();
    }); 
}