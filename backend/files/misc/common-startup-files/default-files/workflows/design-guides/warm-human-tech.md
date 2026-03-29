# Design Profile; Warm Human Tech
WORKFLOW ==> warm-human-tech

## Summary
A friendly, modern technology profile designed to make digital products feel approachable, trustworthy, and emotionally comfortable. It balances clarity and warmth using soft neutrals, rounded geometry, human-centered imagery, and calm accent colors.

## Best use cases
- AI assistants
- health and wellness apps
- education platforms
- consumer SaaS
- coaching platforms
- community products
- family or lifestyle technology

## Visual identity
- Mood: warm, calm, welcoming
- Tone: approachable, trustworthy, human
- Density: medium-low
- Contrast: medium

## Typography
- Heading font: Sora
- Body font: Inter
- Monospace font: JetBrains Mono
- H1 size: clamp(3rem, 6vw, 5.4rem)
- H2 size: clamp(2rem, 3vw, 3rem)
- Body size: 16px
- Line height: 1.7
- Letter spacing: -0.02em for headings

## Color system
- Background: #FBF7F2
- Background secondary: #F4EDE4
- Surface: rgba(255,255,255,0.84)
- Surface elevated: #FFFFFF
- Text primary: #1F2A37
- Text secondary: #6A7280
- Accent primary: #FF8E6E
- Accent secondary: #7CC9B6
- Border: rgba(31,42,55,0.10)
- Glow: rgba(255,142,110,0.12)
- Shadow: rgba(31,42,55,0.08)

## Spacing and layout
- Max content width: 1240px
- Section padding: 96px 28px
- Card padding: 26px
- Grid gap: 24px
- Border radius: 22px
- Border width: 1px

## Components
### Buttons
- Primary button: warm coral filled button
- Secondary button: soft neutral button with border
- Hover: gentle lift and warmer tone
- Radius: 999px
- Padding: 14px 22px

### Cards
- Background: soft airy surface
- Border: subtle warm-gray border
- Shadow: soft low-contrast shadow
- Blur: 8px to 10px
- Radius: 22px

### Forms
- Input background: rgba(255,255,255,0.92)
- Input border: rgba(31,42,55,0.12)
- Input text: #1F2A37
- Input radius: 16px
- Focus state: coral ring with soft shadow

### Navigation
- Height: 78px
- Background: soft translucent header
- Border: subtle divider
- Link style: friendly clear links
- CTA style: rounded warm button

## Motion
- Transition speed: 180ms
- Easing: cubic-bezier(0.22, 1, 0.36, 1)
- Hover effects: soft raise, scale, and color warmth
- Scroll effects: fade and slide reveal
- Glow animation: no by default
- Parallax: minimal

## Imagery direction
- Photography: natural, bright, human-centered, real moments
- Illustration: friendly, simple, inclusive
- 3D: soft rounded objects if needed
- Backgrounds: warm gradients, light texture, gentle shapes
- Icons: rounded and approachable

## Do
- Make interfaces feel emotionally safe
- Use warmth without losing clarity
- Favor rounded geometry and soft spacing
- Use inclusive imagery
- Keep content readable and sincere

## Avoid
- cold enterprise visuals
- harsh black-on-white contrast everywhere
- aggressive futuristic styling
- overly technical language
- noisy interfaces

## Hero direction
Use a clear value proposition, a supportive human image or friendly product scene, and copy that emphasizes help, confidence, and simplicity.

## Implementation notes
This profile works best when content feels compassionate and clear. The visual system should support trust and ease, not hype.

## Tokens
```json
{
  "fonts": {
    "heading": "Sora",
    "body": "Inter",
    "mono": "JetBrains Mono"
  },
  "colors": {
    "bg": "#FBF7F2",
    "bg2": "#F4EDE4",
    "surface": "rgba(255,255,255,0.84)",
    "surface2": "#FFFFFF",
    "text": "#1F2A37",
    "muted": "#6A7280",
    "accent": "#FF8E6E",
    "accent2": "#7CC9B6",
    "border": "rgba(31,42,55,0.10)",
    "glow": "rgba(255,142,110,0.12)",
    "shadow": "rgba(31,42,55,0.08)"
  },
  "layout": {
    "maxWidth": "1240px",
    "sectionPadding": "96px 28px",
    "cardPadding": "26px",
    "gap": "24px",
    "radius": "22px",
    "borderWidth": "1px"
  },
  "motion": {
    "duration": "180ms",
    "easing": "cubic-bezier(0.22, 1, 0.36, 1)"
  }
}
```