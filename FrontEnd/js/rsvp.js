var rsvp = function(id){
    return $.getJSON('http://weddingrsvp7876.azurewebsites.net/api/seats/' + id);
};
var confirmRSVP = function(id, seats)
{
   return $.getJSON('http://weddingrsvp7876.azurewebsites.net/api/seats/' + id + '/confirm/' + seats);
};