import background_0 from '../images/casino_bg_0.jpg'
import background_1 from '../images/casino_bg_1.jpg'
import background_2 from '../images/casino_bg_2.jpg'
import background_3 from '../images/casino_bg_3.jpg'
import background_4 from '../images/casino_bg_4.jpg'
import background_5 from '../images/casino_bg_5.jpg'
import background_6 from '../images/casino_bg_6.jpg'
import background_7 from '../images/casino_bg_7.jpg'
import background_8 from '../images/casino_bg_8.jpg'

const TotalBackgrounds = 9;
let background = -1;
const bgCasino = [background_0, background_1, background_2, background_3, background_4, background_5, background_6, background_7, background_8];

const getBackground = () => {
    background = (background + 1) % TotalBackgrounds;
    return bgCasino[ background ];
}

export default getBackground;