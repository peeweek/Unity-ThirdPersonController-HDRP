namespace ThirdPersonController
{
    /// <summary>
    /// The character is on the ground
    /// </summary>
    public class GroundedCharacterState : CharacterStateBase
    {
        public override void Update(Character character)
        {
            base.Update(character);

            if (character.input == null)
                return;

            character.ApplyGravity(true); // Apply extra gravity

            if (character.input.walk == CharacterInput.ButtonState.JustPressed)
            {
                character.ToggleWalk();
            }

            character.IsSprinting = character.input.sprint == CharacterInput.ButtonState.Pressed || character.input.sprint == CharacterInput.ButtonState.JustPressed;

            if (character.input.jump == CharacterInput.ButtonState.JustPressed)
            {
                character.Jump();
                this.ToState(character, CharacterStateBase.JUMPING_STATE);
            }
            else if (!character.IsGrounded)
            {
                this.ToState(character, CharacterStateBase.IN_AIR_STATE);
            }
        }
    }
}
