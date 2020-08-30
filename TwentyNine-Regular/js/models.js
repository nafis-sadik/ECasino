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
    constructor(ContextId, ContextType, PlayerName, PlayerPic, PlayerId){
        this.contextId = ContextId;
        this.contextType = ContextType;
        this.UserName = PlayerName;
        this.ProfilePicLoc = PlayerPic;
        this.PlayerID = PlayerId;
    }
}