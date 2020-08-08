alert();
FBInstant.initializeAsync()
.then(() => {
    alert();
    let progress = 0;
    let interval = setInterval(() => {
        progress += 3;
        FBInstant.setLoadingProgress(progress);
        if(progress >= 95){
            clearInterval(interval);
            FBInstant.startGameAsync()
            .then(() => {
                let player = {
                    contextId: FBInstant.context.getID(),
                    contextType: FBInstant.context.getType(),
                    playerName: FBInstant.player.getName(),
                    playerPic: FBInstant.player.getPhoto(),
                    playerId: FBInstant.player.getID()
                }
                console.log(player);
            })
        }
    }, 100);
});