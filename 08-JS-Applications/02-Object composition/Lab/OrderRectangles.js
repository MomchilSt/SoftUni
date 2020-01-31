const template = {
    width: 0,
    height: 0,
    area: function() {
        return this.width * this.height;
    },
    compareTo: function(obj) {
        return this.area() - obj.area() === 0 ?
         this.width - obj.width :
         this.area() - obj.area();
    }
};

function solve(data){
    return data.map(([width, height]) => Object.assign(
        Object.create(template),
        {width, height}
    ))
    .sort((b,a) => a.compareTo(b));
}