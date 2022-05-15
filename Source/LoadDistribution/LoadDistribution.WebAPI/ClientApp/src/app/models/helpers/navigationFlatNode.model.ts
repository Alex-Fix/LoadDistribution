import Navigation from "./navigation.model";

export default class NavigationFlatNode {
    literal: string;
    path: string | null;
    expandable: boolean;
    level: number;

    constructor(literal: string, path: string | null, expandable: boolean, level: number) {
        this.literal = literal;
        this.path = path;
        this.expandable = expandable;
        this.level = level;
    }

    static toNavigationFlatNode(navigation: Navigation, level: number): NavigationFlatNode {
        return new NavigationFlatNode(
            navigation.literal, 
            navigation.path, 
            !!(navigation.children && navigation.children.length > 0), 
            level);
    }
}