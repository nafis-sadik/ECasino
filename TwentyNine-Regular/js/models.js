const RoutingConst = {
    Host: 'https://localhost:8029',
    CasinoBE: 'https://localhost:44371',
    Backgrounds : {
        geometric_shape_1: '/assets/realistic-elegant-geometric-shapes-background/img.jpg',
        geometric_shape_2: '/assets/gold-luxury-background-concept/img.jpg'
    },
    Components : {
        authGate: '/views/authGate/',
        Home: '/views/Home/'
    }
}

class Player {
    static Instance = '';
    constructor(_contextId, _contextType, _playerName, _playerPicUrl, _playerId){
        if(Player.Instance instanceof Player)
            return Player.Instance;
        
        if(_playerId == null || _playerId == NaN || _playerId == undefined){
            console.error('Invalid Player Id recieved from sdk');
            return;
        }
        
        this.ContextID = _contextId;
        this.ContextType = _contextType;
        
        this.UserName = _playerName;
        this.ProfilePicLoc = _playerPicUrl;
        this.PlayerID = _playerId;
        
        Player.Instance = this; 
    }
}