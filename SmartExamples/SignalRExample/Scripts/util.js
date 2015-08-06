$(function () {

    var hub = $.connection.moveShape, //set hub with the server side class 
        $shape = $('#shape');

    hub.client.usersConnected = function (n) {
        //show the number of users connected inside a div 
        $('#count').text(n);

        //this instanciate the  
        //usersConnected function receiving the numUsers parameter which is the number of users connected 
    };

    hub.client.shapeMoved = function (x, y) { //this instanciate the shapeMoved function receiving x, y  
        $shape.css({ left: x, top: y }); //this moves the shape in the clients to the coords (x, y)  
    };

    $.connection.hub.start().done(function () {//when the connection is ready, we going to make the shape draggable 
        $shape.draggable({
            drag: function () { //when the user drag the shape, we going to  
                //send to the server the x, y values 
                hub.server.dragShape(this.offsetLeft, this.offsetTop || 0);
            }
        });
    });
});