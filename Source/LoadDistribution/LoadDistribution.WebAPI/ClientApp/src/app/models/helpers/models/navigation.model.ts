export default class Navigation {
    literal: string;
    path: string | null;
    children: Navigation[] | null;

    
    constructor(literal: string, path: string | null = null, children: Navigation[] | null = null) {
        this.literal = literal;
        this.path = path;
        this.children = children;
    }
}