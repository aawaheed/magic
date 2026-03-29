# Design Profile; Elegant Dark Commerce
WORKFLOW ==> elegant-dark-commerce

## Summary
A cinematic dark commerce profile optimized for premium product presentation, elevated conversion flows, and luxury merchandising. It combines high contrast, rich media framing, refined type, and polished product-first composition.

## Best use cases
- premium ecommerce
- fashion brands
- beauty brands
- automotive launches
- watch and jewelry brands
- audio products
- luxury DTC sites

## Visual identity
- Mood: cinematic, refined, aspirational
- Tone: premium, luxurious, decisive
- Density: medium-low
- Contrast: high

## Typography
- Heading font: Manrope
- Body font: Inter
- Monospace font: JetBrains Mono
- H1 size: clamp(3.2rem, 6vw, 5.8rem)
- H2 size: clamp(2.1rem, 3vw, 3.3rem)
- Body size: 16px
- Line height: 1.65
- Letter spacing: -0.025em for headings

## Color system
- Background: #0A0A0D
- Background secondary: #121218
- Surface: rgba(255,255,255,0.05)
- Surface elevated: rgba(255,255,255,0.09)
- Text primary: #F5F1EA
- Text secondary: #B8AEA3
- Accent primary: #D8B26E
- Accent secondary: #8D6BFF
- Border: rgba(255,255,255,0.12)
- Glow: rgba(216,178,110,0.16)
- Shadow: rgba(0,0,0,0.42)

## Spacing and layout
- Max content width: 1280px
- Section padding: 104px 28px
- Card padding: 28px
- Grid gap: 26px
- Border radius: 20px
- Border width: 1px

## Components
### Buttons
- Primary button: warm metallic accent button
- Secondary button: dark glass button with border
- Hover: subtle raise and sheen feel
- Radius: 999px
- Padding: 14px 24px

### Cards
- Background: rich translucent charcoal
- Border: low-contrast premium border
- Shadow: deep soft shadow
- Blur: 10px to 14px
- Radius: 20px

### Forms
- Input background: rgba(255,255,255,0.06)
- Input border: rgba(255,255,255,0.12)
- Input text: #F5F1EA
- Input radius: 14px
- Focus state: gold-tinted border and shadow

### Navigation
- Height: 80px
- Background: dark transparent to luxe surface on scroll
- Border: subtle bottom divider
- Link style: refined muted links
- CTA style: warm premium button

## Motion
- Transition speed: 220ms
- Easing: cubic-bezier(0.22, 1, 0.36, 1)
- Hover effects: zoom, glow polish, subtle lift
- Scroll effects: fade, scale reveal, image pan
- Glow animation: minimal ambient shimmer
- Parallax: yes, subtle for media

## Imagery direction
- Photography: dramatic lighting, macro details, premium finishes
- Illustration: minimal and elegant if used
- 3D: premium product render acceptable
- Backgrounds: dark gradients, spotlight scenes, depth haze
- Icons: fine-line luxury icons

## Do
- Let products dominate the viewport
- Use premium contrast and spacing
- Keep copy concise and confident
- Use warm metallic accents carefully
- Frame imagery like editorial commerce

## Avoid
- discount-store styling
- too many promotion badges
- neon overload
- cluttered product grids
- overusing multiple accent colors

## Hero direction
Use one hero product, dramatic lighting, a concise luxury headline, and a premium CTA cluster with supporting trust or craftsmanship messaging.

## Implementation notes
The design should feel expensive, not flashy. Prioritize composition, texture, lighting, and restraint over busy merchandising.

## Tokens
```json
{
  "fonts": {
    "heading": "Manrope",
    "body": "Inter",
    "mono": "JetBrains Mono"
  },
  "colors": {
    "bg": "#0A0A0D",
    "bg2": "#121218",
    "surface": "rgba(255,255,255,0.05)",
    "surface2": "rgba(255,255,255,0.09)",
    "text": "#F5F1EA",
    "muted": "#B8AEA3",
    "accent": "#D8B26E",
    "accent2": "#8D6BFF",
    "border": "rgba(255,255,255,0.12)",
    "glow": "rgba(216,178,110,0.16)",
    "shadow": "rgba(0,0,0,0.42)"
  },
  "layout": {
    "maxWidth": "1280px",
    "sectionPadding": "104px 28px",
    "cardPadding": "28px",
    "gap": "26px",
    "radius": "20px",
    "borderWidth": "1px"
  },
  "motion": {
    "duration": "220ms",
    "easing": "cubic-bezier(0.22, 1, 0.36, 1)"
  }
}
```