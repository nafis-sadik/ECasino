FBInstant.initializeAsync()
  .then(function(){}
  // Start loading game assets here
);

FBInstant.startGameAsync()
  .then(function() {
  // Retrieving context and player information can only be done
  // once startGameAsync() resolves
  var contextId = FBInstant.context.getID();
  var contextType = FBInstant.context.getType();

  var playerName = FBInstant.player.getName();
  var playerPic = FBInstant.player.getPhoto();
  var playerId = FBInstant.player.getID();

  // Once startGameAsync() resolves it also means the loading view has 
  // been removed and the user can see the game viewport

  game.start();
});

FBInstant.updateAsync({
    action: 'CUSTOM',
    cta: 'Play',
    image: base64Picture,
    text: {
      default: 'Edgar played their move',
      localizations: {
        en_US: 'Edgar played their move',
        es_LA: '\u00A1Edgar jug\u00F3 su jugada!'
      }
    }
    template: 'play_turn',
    data: { myReplayData: '...' },
    strategy: 'IMMEDIATE',
    notification: 'NO_PUSH'
  }).then(function() {
    // Closes the game after the update is posted.
    FBInstant.quit();
  });