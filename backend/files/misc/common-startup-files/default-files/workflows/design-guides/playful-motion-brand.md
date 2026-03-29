# Design Profile; Playful Motion Brand
WORKFLOW ==> playful-motion-brand

## Summary
A modern expressive profile combining strong visual friendliness, animated energy, colorful accents, and delightful interaction design. It is meant for brands that want to feel alive, memorable, and contemporary without becoming childish or chaotic.

## Best use cases
- consumer apps
- creative SaaS
- education platforms
- startup marketing sites
- mobile-first products
- creator economy tools
- youth-oriented brands

## Visual identity
- Mood: vibrant, optimistic, dynamic
- Tone: friendly, inventive, modern
- Density: medium-low
- Contrast: medium-high

## Typography
- Heading font: Outfit
- Body font: Inter
- Monospace font: JetBrains Mono
- H1 size: clamp(3.2rem, 6vw, 5.8rem)
- H2 size: clamp(2.1rem, 3vw, 3.2rem)
- Body size: 16px
- Line height: 1.65
- Letter spacing: -0.025em for headings

## Color system
- Background: #FFF9FD
- Background secondary: #F5F3FF
- Surface: rgba(255,255,255,0.82)
- Surface elevated: #FFFFFF
- Text primary: #1A1F36
- Text secondary: #66708A
- Accent primary: #7A5CFF
- Accent secondary: #FF6FB5
- Border: rgba(26,31,54,0.10)
- Glow: rgba(122,92,255,0.18)
- Shadow: rgba(26,31,54,0.10)

## Spacing and layout
- Max content width: 1240px
- Section padding: 96px 28px
- Card padding: 26px
- Grid gap: 24px
- Border radius: 24px
- Border width: 1px

## Components
### Buttons
- Primary button: vibrant filled button with soft glow
- Secondary button: tinted soft button with border
- Hover: scale, lift, and color pop
- Radius: 999px
- Padding: 14px 22px

### Cards
- Background: airy translucent light surface
- Border: subtle playful tint border
- Shadow: soft colorful depth
- Blur: 10px to 14px
- Radius: 24px

### Forms
- Input background: rgba(255,255,255,0.9)
- Input border: rgba(26,31,54,0.12)
- Input text: #1A1F36
- Input radius: 16px
- Focus state: colorful ring and brighter border

### Navigation
- Height: 78px
- Background: soft floating translucent header
- Border: subtle divider or none
- Link style: friendly clean links
- CTA style: colorful pill button

## Motion
- Transition speed: 220ms
- Easing: cubic-bezier(0.22, 1, 0.36, 1)
- Hover effects: bounce-lite, scale, reveal, glow
- Scroll effects: fade, rise, stagger, shape drift
- Glow animation: subtle ambient pulse allowed
- Parallax: minimal to moderate on decorative elements

## Imagery direction
- Photography: bright, upbeat, expressive
- Illustration: abstract shapes, playful forms, brand characters if relevant
- 3D: soft glossy forms encouraged
- Backgrounds: gradients, blobs, soft mesh color fields
- Icons: rounded, friendly, slightly bold

## Do
- Use motion to reinforce delight
- Keep the palette intentional and controlled
- Pair friendliness with clarity
- Use soft rounded geometry consistently
- Make CTAs feel inviting

## Avoid
- childish randomness
- too many simultaneous animations
- weak information hierarchy
- muddy gradients
- using every accent everywhere

## Hero direction
Use a high-energy headline, vibrant supporting shapes or 3D objects, animated detail, and a CTA area that feels joyful but still clear.

## Implementation notes
Motion matters here, but choreography must remain clean. Use 1 to 2 dominant brand accents and let spacing keep the system disciplined.

## Tokens
```json
{
  "fonts": {
    "heading": "Outfit",
    "body": "Inter",
    "mono": "JetBrains Mono"
  },
  "colors": {
    "bg": "#FFF9FD",
    "bg2": "#F5F3FF",
    "surface": "rgba(255,255,255,0.82)",
    "surface2": "#FFFFFF",
    "text": "#1A1F36",
    "muted": "#66708A",
    "accent": "#7A5CFF",
    "accent2": "#FF6FB5",
    "border": "rgba(26,31,54,0.10)",
    "glow": "rgba(122,92,255,0.18)",
    "shadow": "rgba(26,31,54,0.10)"
  },
  "layout": {
    "maxWidth": "1240px",
    "sectionPadding": "96px 28px",
    "cardPadding": "26px",
    "gap": "24px",
    "radius": "24px",
    "borderWidth": "1px"
  },
  "motion": {
    "duration": "220ms",
    "easing": "cubic-bezier(0.22, 1, 0.36, 1)"
  }
}
```