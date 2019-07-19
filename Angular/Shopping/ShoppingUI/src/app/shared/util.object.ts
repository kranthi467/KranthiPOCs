function getKeys(obj: object): string[]
{
    var keys = [];
    for(var key in obj){
       keys.push(key);
    }
    return keys;
}

function readProp(obj: object, prop: string): string {
    return obj[prop];
}

export {
    getKeys,
    readProp
}