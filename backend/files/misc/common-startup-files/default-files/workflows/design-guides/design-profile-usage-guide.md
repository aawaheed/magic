# Design Profile Usage Guide
WORKFLOW ==> design-profile-usage-guide

## Purpose
This guide explains how to combine design profiles and page archetypes to improve default frontend quality.

## Core rule
Use exactly one design profile and one page archetype as defaults when generating a new page, unless the user explicitly asks for a custom style.

## Recommended process
1. Identify the page type.
2. Identify the desired style.
3. Select one archetype.
4. Select one design profile.
5. Use both as constraints for layout and CSS.
6. Only improvise where the files leave room.

## Suggested matching defaults
- AI startup: Dark Futuristic AI + AI Product Homepage
- SaaS app: Glassmorphism SaaS or Bento Startup + SaaS Landing Page
- Luxury brand: Minimal Luxury + SaaS Landing Page or custom editorial structure
- Creative portfolio: Editorial Portfolio + Creative Portfolio Homepage
- Admin app: Dark Futuristic AI or Bento Startup + Admin Dashboard
- Login page: match the parent product profile + Login Signup Page

## Implementation guidance
- Apply profile typography, color, spacing, radius, border, and motion tokens first.
- Apply archetype section order second.
- Then generate page-specific copy and visuals.
- Keep CTA styling consistent across the page.
- Respect the profile's Do and Avoid sections.

## Retrieval guidance
Use narrow lookups such as:
- Design Profile dark futuristic AI
- Page Archetype SaaS landing page
- Design Profile minimal luxury
- Page Archetype admin dashboard

Avoid vague lookups such as:
- modern design
- good website style

## Why this helps
This reduces generic styling, improves consistency, and creates stronger first-pass output for websites and app interfaces.

## Expansion plan
Next profiles to add:
- Neo Brutalist Creative
- Soft Premium Corporate
- Elegant Dark Commerce
- High Contrast Dashboard
- Immersive 3D Product Showcase

Next archetypes to add:
- Pricing Page
- Documentation Page
- Agency Website
- E-commerce Product Page
- Marketing Microsite