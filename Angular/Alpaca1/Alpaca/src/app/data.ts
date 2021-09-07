import { CategoryImages } from "./models/category-images";

export const pathRoot: string = 'assets/images/';

//available customization options
export const parts: CategoryImages[] = [
    {
        category: 'ears',
        paths: [
            'default.png',
            'tilt-backward.png',
            'tilt-forward.png'
        ]
    },
    {
        category: 'eyes',
        paths: [
            'default.png',
            'angry.png',
            'naughty.png',
            'panda.png',
            'star.png'
        ]
    },
    {
        category: 'hair',
        paths: [
            'default.png',
            'bang.png',
            'curls.png',
            'elegant.png',
            'quiff.png',
            'short.png'
        ]
    },
    {
        category: 'legs',
        paths: [
            'default.png',
            'bubble-tea.png',
            'cookie.png',
            'game-console.png',
            'tilt-backward.png',
            'tilt-forward.png'
        ]
    },
    {
        category: 'necks',
        paths: [
            'default.png',
            'bend-backward.png',
            'bend-forward.png',
            'thick.png'
        ]
    },
    {
        category: 'accessories',
        paths: [
            'none', //option to have no accessory
            'earings.png',
            'flower.png',
            'glasses.png',
            'headphone.png'
        ]
    },
    {
        category: 'mouths',
        paths: [
            'default.png',
            'astonished.png',
            'eating.png',
            'laugh.png',
            'tongue.png'
        ]
    }
];