var utils = {
    range: function range(min, max) {
        return Array.from({ length: max - min + 1 }, function (_, i) {
            return min + i;
        });
    }
};

export { utils as default };