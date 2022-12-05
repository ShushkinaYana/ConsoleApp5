namespace ConsoleApp5
{
    internal class Program
    {
        public class Character
        {

        }

        public enum ProgramistState
        {
            Idle, Moving, Attack
        }

        public class Programist
        {


            private Character m_targetCharacter = null;
            private bool m_atTarget = false;
            private ProgramistState m_state = ProgramistState.Idle;
            private Dictionary<ProgramistState, BaseProgramistState> m_states = new Dictionary<ProgramistState, BaseProgramistState>();
            public Programist()
            {
                m_states.Add(ProgramistState.Idle, new ProgramistIdleState(this));
                m_states.Add(ProgramistState.Moving, new ProgramistMoveState(this));
                m_states.Add(ProgramistState.Attack, new ProgramistAttackState(this));

            }

            public void ChangeState(ProgramistState state)
            {
                m_state = state;
            }

            public void FindCharacter()
            {
                m_targetCharacter = new Character();
                ChangeState(ProgramistState.Moving);
            }

            public void Move()
            {

                ChangeState(ProgramistState.Attack);

            }

            public void Attack()
            {
                m_targetCharacter = null;

                ChangeState(ProgramistState.Idle);

            }

            public void Update()
            {

                m_states[m_state].Update();
            }
            public abstract class BaseProgramistState
            {
                protected readonly Programist m_prog;

                public BaseProgramistState(Programist prog)
                {
                    m_prog = prog;
                }
                public abstract void Update();

            }
            public class ProgramistIdleState : BaseProgramistState
            {
                public ProgramistIdleState(Programist prog) : base(prog) { }

                public override void Update()
                {
                    m_prog.FindCharacter();
                }

            }

            public class ProgramistMoveState : BaseProgramistState
            {
                public ProgramistMoveState(Programist prog) : base(prog) { }

                public override void Update()
                {
                    m_prog.Move();
                }

            }

            public class ProgramistAttackState : BaseProgramistState
            {
                public ProgramistAttackState(Programist prog) : base(prog) { }

                public override void Update()
                {
                    m_prog.Attack();
                }

            }
        }
    }
}