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
        // Load main css
        $.ajax({
            url: RoutingConst.Host + '/main.css',
            success: (res) => {
                $('#MainStyle').append(res);
            },
            error: (res) => {
                console.error(res);
            }
        });
        
        // Load context data
        let ContextId = FBInstant.context.getID();
        let ContextType = FBInstant.context.getType();
        
        // Load Player data
        let PlayerName = FBInstant.player.getName();
        let PlayerPic = FBInstant.player.getPhoto();
        let PlayerId = FBInstant.player.getID();
        
        // Creating singleton player object
        let currentPlayer = new Player(ContextId, ContextType, PlayerName, PlayerPic, PlayerId);

        // starting application
        appStart(currentPlayer);
        game.start();
    }); 
}