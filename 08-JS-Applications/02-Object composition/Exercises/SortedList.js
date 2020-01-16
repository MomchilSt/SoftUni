function solve() {
    return {
        elements: [],
        size: 0,
        add: function(element) {
            this.elements.push(element);
            this.elements.sort((a, b) => a - b);
            this.size++;
        },
        remove: function(i) {
            if (this.elements[i] === undefined) {
                throw new Error('Invalid Index');
            }

            this.elements.splice(i, 1);
            this.elements.sort((a, b) => a - b);
            this.size--;
        },
        get: function(i) {
            if (this.elements[i] === undefined) {
                throw new Error('Invalid Index');
            }
            return this.elements[i];
        },
    }
}